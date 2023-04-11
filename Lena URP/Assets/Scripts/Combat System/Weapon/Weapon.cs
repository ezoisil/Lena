using Holding;
using UnityEngine;

namespace Combat_System.Weapon
{

    public class Weapon : IHoldable
    {
        protected Transform HoldTransform;

        public Transform HandleTransform { get => HoldTransform; }
    }

}
