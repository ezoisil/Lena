namespace Combat_System.Hurt_Hit
{

    public interface IHitDetector 
    {
        public IHitResponder HitResponder { get; set; }

        public void CheckHit();
    }

}
