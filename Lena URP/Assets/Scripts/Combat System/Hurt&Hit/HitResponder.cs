using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public class HitResponder : MonoBehaviour, IHitResponder
    {
        [SerializeField] private int _damage = 1;
        [SerializeField] private HitBox _hitBox;
        [SerializeField] private bool _isAttacking;

        public int Damage { get => _damage; }

        private void Start()
        {
            _hitBox.HitResponder = this;
        }

        private void Update()
        {
            if(_isAttacking)
                _hitBox.CheckHit();
        }

        public bool CheckHit(HitData data)
        {
            throw new System.NotImplementedException();
        }

        public void Response(HitData data)
        {
            throw new System.NotImplementedException();
        }
    }

}
