using UnityEngine;

namespace Combat_System
{

    public interface IHitResponder 
    {
        public int Damage { get; }

        public bool CheckHit(HitData data);
        public void Response(HitData data);

    }

}
