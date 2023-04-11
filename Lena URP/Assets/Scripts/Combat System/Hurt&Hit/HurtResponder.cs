using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public class HurtResponder : MonoBehaviour, IHurtResponder, ITargetable
    {
        [SerializeField] private bool _isTargetable;
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private Rigidbody _rigidbody;

        private List<IHurtBox> _hurtBoxes = new List<IHurtBox>();

        public bool IsTargetable { get => _isTargetable; }
        public Transform TargetTransform { get => _targetTransform; }

        private void Start()
        {
            _hurtBoxes = GetComponentsInChildren<IHurtBox>().ToList();
            foreach (var hurtBox in _hurtBoxes)
            {
                hurtBox.HurtResponder = this;
            }
        }

        public bool CheckHit(HitData data)
        {
            return true;
        }

        public void Response(HitData data)
        {
            Debug.Log("Hit response");
        }


    }

}
