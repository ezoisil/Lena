using System;
using System.Collections;
using System.Collections.Generic;
using RegularDuck;
using UnityEngine;

namespace RegularDuck
{
	public abstract class DamageGiver : MonoBehaviour
	{
		[Header("Damage Giver Settings")] [SerializeField]
		protected float _delay = 0;
		
		[SerializeField] private LayerMask _targetLayerMask;
		
		public float Damage;

		protected List<Damageable> _currentTargets = new List<Damageable>();
		protected Dictionary<Damageable, float> _damageTimers= new Dictionary<Damageable,float>();

		#region Events

		public delegate void DamageGiverHandler();

		public event DamageGiverHandler OnBeforeGivingDamage;
		public event DamageGiverHandler OnGivingDamage;
		public event DamageGiverHandler OnAfterGivingDamage;

		#endregion

		protected virtual void OnDestroy()
		{
			StopAllCoroutines();
		}

		public virtual void AddNewTarget(Damageable damageable)
		{
			_currentTargets.Add(damageable);
			_damageTimers.Add(damageable, 0);
		}

		protected virtual bool TryGiveDamage(Damageable target)
		{
			if  (!IsOnTargetLayer(target.gameObject)) return false;
			StartCoroutine(DamageGivingProcess(target));
			return true;
		}

		protected virtual IEnumerator DamageGivingProcess(Damageable damageable)
		{
			OnBeforeGivingDamage?.Invoke();
			
			yield return new WaitForSeconds(_delay);
			
			GiveDamage(damageable);
			OnAfterGivingDamage?.Invoke();
		}

		protected virtual void GiveDamage(Damageable damageable)
		{
			damageable.TryTakeDamage(Damage);
			OnGivingDamage?.Invoke();
		}

		protected virtual void RemoveTarget(Damageable damageable)
		{
			_currentTargets.Remove(damageable);
			_damageTimers.Remove(damageable);
		}

		#region Helpers

		protected bool IsOnTargetLayer(GameObject target)
		{
			return (_targetLayerMask.value & (1 << target.layer)) > 0;
		}

		#endregion


	}

}