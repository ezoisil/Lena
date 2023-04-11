using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public class HitBox : MonoBehaviour, IHitDetector
    {
        [SerializeField] private BoxCollider _collider;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] public HurtBoxMask _hurtBoxMask = HurtBoxMask.Enemy;

        [SerializeField] private float _thickness = 0.025f;
        private IHitResponder _hitResponder;

        public IHitResponder HitResponder { get => _hitResponder; set => _hitResponder = value; }

        private float _distance;
        private Vector3 _direction;
        private Vector3 _center;
        private Vector3 _startPoint;
        private Vector3 _halfExtents;
        private Quaternion _orientation;
        private RaycastHit[] _results;
        private Vector3 _lossyScale;
        private int _size;

        public void CheckHit()
        {
            var size1 = _collider.size;
            _lossyScale = transform.lossyScale;
            Vector3 scaledSize = new Vector3(
            size1.x * _lossyScale.x,
            size1.y * _lossyScale.y,
            size1.z * _lossyScale.z
            );

            _distance = scaledSize.y - _thickness;
            _direction = transform.up;
            _center = transform.TransformPoint(_collider.center);
            _startPoint = _center - _direction * (_distance / 2);
            _halfExtents = new Vector3(scaledSize.x, _thickness, scaledSize.z) / 2;
            _orientation = transform.rotation;

            _results = new RaycastHit[10];
            _size = Physics.BoxCastNonAlloc(_startPoint, _halfExtents, _direction, _results, _orientation, _distance, _layerMask);

            for (int i = 0; i < _size; i++)
            {
                if (TryGetComponent(out IHurtBox hurtBox))
                {
                    if (!hurtBox.IsActive) return;
                    if(!_hurtBoxMask.HasFlag(hurtBox.Type)) return;

                    RaycastHit hit = _results[i];

                    var hitData = new HitData
                    {
                        Damage = _hitResponder?.Damage ?? 0,
                        HitPoint = hit.point == Vector3.zero ? _center : hit.point,
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
