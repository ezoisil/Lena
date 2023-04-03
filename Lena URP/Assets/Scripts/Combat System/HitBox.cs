using UnityEngine;

namespace Combat_System
{

    public class HitBox : MonoBehaviour, IHitDetector
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private float _thickness = 0.025f;
        private IHitResponder _hitResponder;

        public IHitResponder HitResponder
        {
            get => _hitResponder;
            set => _hitResponder = value;
        }

        private float distance;
        private Vector3 direction;
        private Vector3 center;
        private Vector3 startPoint;
        private Vector3 halfExtents;
        private Quaternion orientation;
        private RaycastHit[] results;
        private int size;
        public void CheckHit()
        {
            var size1 = _collider.size;
            Vector3 scaledSize = new Vector3(
            size1.x * transform.lossyScale.x,
            size1.y * transform.lossyScale.y,
            size1.z * transform.lossyScale.z
            );

            distance = scaledSize.y - _thickness;
            direction = transform.up;
            center = transform.TransformPoint(_collider.center);
            startPoint = center - direction * (distance / 2);
            halfExtents = new Vector3(scaledSize.x, _thickness, scaledSize.z) / 2;
            orientation = transform.rotation;

            results = new RaycastHit[10];
            size = Physics.BoxCastNonAlloc(startPoint, halfExtents, direction, results, orientation, distance, _layerMask);

            for (int i = 0; i < size; i++)
            {
                if (TryGetComponent(out IHurtBox hurtBox))
                {
                    if (!hurtBox.IsActive) return;

                    RaycastHit hit = results[i];

                    var hitData = new HitData
                    {
                        Damage = _hitResponder?.Damage ?? 0,
                        HitPoint = hit.point == Vector3.zero ? center : hit.point,
                        HitNormal = hit.normal,
                        HurtBox = hurtBox,
                        HitDetector = this
                    };

                    if (!hitData.Validate()) return;

                    hitData.HitDetector.HitResponder?.Response(hitData);
                    hitData.HurtBox.HurtResponder?.Response(hitData);

                }
            }
        }
    }

}
