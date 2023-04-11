using UnityEngine;

namespace Combat_System.Hurt_Hit
{

    public class HitData
    {
        public int Damage;
        public Vector3 HitPoint;
        public Vector3 HitNormal;
        public IHurtBox HurtBox;
        public IHitDetector HitDetector;

        public bool Validate()
        {
            if (HurtBox == null)
                return false;
            if (!HurtBox.CheckHit(this))
                return false;
            if (HurtBox.HurtResponder != null && !HurtBox.HurtResponder.CheckHit(this))
                return false;
            return HitDetector.HitResponder == null || HitDetector.HitResponder.CheckHit(this);
        }
    }

}
