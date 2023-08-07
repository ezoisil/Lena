using System.Collections;
using Holding;
using UnityEngine;
using UnityEngine.Lumin;

namespace Combat_System.Weapon
{
    public class Weapon : MonoBehaviour
    {
        protected float Cooldown;

        private bool _isCooldownReady;
        
        public virtual bool TryAttack()
        {
            if (!CanAttack()) return false;
            
            Attack();
            return true;
        }

        protected virtual bool CanAttack()
        {
            if (!_isCooldownReady) return false;
            
            return true;
        }

        protected virtual void Attack()
        {
            StartCoroutine(CooldownCoroutine());
        }

        protected virtual IEnumerator CooldownCoroutine()
        {
            yield return new WaitForSeconds(Cooldown);

            _isCooldownReady = true;
        }
    }

}
