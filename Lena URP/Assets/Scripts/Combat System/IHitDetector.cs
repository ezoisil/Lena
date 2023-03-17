using UnityEngine;

namespace Combat_System
{

    public interface IHitDetector 
    {
        public IHitResponder HitResponder { get; set; }

        public void CheckHit();
    }

}
