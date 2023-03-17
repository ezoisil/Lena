using UnityEngine;

namespace Combat_System
{

    public interface IHurtResponder
    {
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }

}
