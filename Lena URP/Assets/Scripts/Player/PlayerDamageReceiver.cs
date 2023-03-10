using System;
using Combat_System;
using Core.Scriptable_Variables;
using Scriptable_Variables;
using UnityEngine;

namespace Player
{

    public class PlayerDamageReceiver : DamageReceiver
    {
        [SerializeField] protected FloatVariable _playerCurrentHealth;
        [SerializeField] protected FloatVariable _playerMaxHealth;

        protected override void LoseHealth(float damage)
        {
            base.LoseHealth(damage);
            _playerCurrentHealth.ChangeValue(CurrentHealth);
        }

        protected override void Heal(float healAmount)
        {
            base.Heal(healAmount);
            _playerCurrentHealth.ChangeValue(CurrentHealth);
        }
    }

}
