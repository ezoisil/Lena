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
            get { return _hitResponder; }
            set { _hitResponder = value; }
        }

        public void CheckHit()
        {
            Vector3 scaledSize = new Vector3(
            _collider.size.x * transform.lossyScale.x,
            _collider.size.y * transform.lossyScale.y,
            _collider.size.z * transform.lossyScale.z
            );

            float distance = scaledSize.y - _thickness;
            Vector3 direction = transform.up;
            Vector3 center = transform.TransformPoint(_collider.center);
            Vector3 startPoint = center - direction * (distance / 2);
            Vector3 halfExtents = new Vector3(scaledSize.x, _thickness, scaledSize.z) / 2;
            Quaternion orientation = transform.rotation;

            HitData hitdata = null;
            IHurtBox hurtBox = null;
            RaycastHit[] results = new RaycastHit[10];
            var size = Physics.BoxCastNonAlloc(startPoint, halfExtents, direction, results, orientation, distance, _layerMask);

            for (int i = 0; i < size; i++)
            {
                if (TryGetComponent(out hurtBox))
                {
                    if(!hurtBox.Active) return;

                    RaycastHit hit = results[i];

                    hitdata = new HitData
                    {
                        Damage =  _hitResponder?.Damage ?? 0,
                        HitPoint = hit.point == Vector3.zero ? center : hit.point,
                        HitNormal = hit.normal,
                        HurtBox = hurtBox,
                        HitDetector = this
                    };
                    
                    if(!hitdata.Validate()) return;
                    
                    hitdata.HitDetector.HitResponder?.Response(hitdata);
                    hitdata.HurtBox.HurtResponder?.Response(hitdata);
                    
                }
            }
        }
    }

}
