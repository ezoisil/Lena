using UnityEngine;

namespace Combat_System
{

    public class DefaultTargetable : MonoBehaviour,ITargetable
    {
        [SerializeField] private bool _isTargetable;
        [SerializeField] private Transform _targetTransform;

        public bool IsTargetable { get => _isTargetable; }
        public Transform TargetTransform { get => _targetTransform; }
    }

}
