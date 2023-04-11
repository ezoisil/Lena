namespace Combat_System.Hurt_Hit
{

    public interface IHitResponder 
    {
        public int Damage { get; }

        public bool CheckHit(HitData data);
        public void Response(HitData data);

    }

}
