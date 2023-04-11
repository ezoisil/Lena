using System;

namespace Combat_System.Hurt_Hit
{

    [Flags] public enum HurtBoxMask
    {
        None = 0,
        Player = 1 << 0,
        Enemy = 1 << 1,
        Ally = 1 << 2
    }

}
