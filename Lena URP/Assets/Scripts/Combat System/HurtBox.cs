using UnityEngine;

namespace Combat_System
{

    public class HurtBox : MonoBehaviour, IHurtBox
    {
        [SerializeField] private bool _isActive = true;
        [SerializeField] private GameObject _owner = null;
        [SerializeField] private HurtBoxType _type;
        private IHurtResponder _hurtResponder;

        public bool IsActive { get => _isActive; }

        public GameObject Owner { get => _owner; }
        public HurtBoxType Type { get => _type; }

        public Transform Transform { get => transform; }

        public IHurtResponder HurtResponder { get => _hurtResponder; set => _hurtResponder = value; }

        public bool CheckHit(HitData data)
        {
            if (_hurtResponder == null)
                Debug.Log("No Responder");

            return true;
        }
    }

}
