using UnityEngine;

namespace Combat_System
{

    public interface ITargetable
    {
        public bool IsTargetable { get; }
        public Transform TargetTransform { get; }
    }

}
