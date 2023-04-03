using System;
using UnityEngine;

namespace Combat_System
{

    public interface IHurtBox 
    {
        public bool IsActive { get; }
        public GameObject Owner { get; }
        public Transform Transform { get; }
        public IHurtResponder HurtResponder { get; set; }
        public bool CheckHit(HitData data);
    }

}
