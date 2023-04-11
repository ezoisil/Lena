using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public interface IHurtBox 
    {
        public bool IsActive { get; }
        public GameObject Owner { get; }
        public HurtBoxType Type { get; }
        public Transform Transform { get; }
        public IHurtResponder HurtResponder { get; set; }
        public bool CheckHit(HitData data);
    }

}
