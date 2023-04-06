using System;
using UnityEngine;

namespace Combat_System
{

    [Flags] public enum HurtBoxMask
    {
        None = 0,
        Player = 1 << 0,
        Enemy = 1 << 1,
        Ally = 1 << 2
    }

}
