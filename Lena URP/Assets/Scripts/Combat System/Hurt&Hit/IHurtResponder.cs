namespace Combat_System.Hurt_Hit
{

    public interface IHurtResponder
    {
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }

}
