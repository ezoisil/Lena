using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    [CreateAssetMenu(fileName = "Player Stats", menuName = "Player/Player Stats")]
    public class PlayerStats : ScriptableObject
    {
        public FloatVariable MovementSpeed;
        public FloatVariable BaseHealth;
        public FloatVariable DashSpeed;
    }

}
