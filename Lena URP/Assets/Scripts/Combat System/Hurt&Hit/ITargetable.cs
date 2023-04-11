using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public interface ITargetable
    {
        public bool IsTargetable { get; }
        public Transform TargetTransform { get; }
    }

}
