using UnityEngine;

namespace Combat_System
{

    public enum HurtBoxType 
    {
        Player = 1 << 0,
        Enemy = 1 << 1,
        Ally = 1 << 2
    }

}
