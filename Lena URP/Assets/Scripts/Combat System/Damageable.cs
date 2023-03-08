using UnityEngine;
using RegularDuck;

namespace RegularDuck
{
	public class Damageable : MonoBehaviour
	{
		protected enum HealthUpgradeBehaviour
		{
			MaxOutTheHealthOnUpgrade,
			AddTheDifference
		}

		[SerializeField] private HealthUpgradeBehaviour _healthUpgradeBehaviour;

		protected float _initialHealth;
		protected float _runtimeHealth;
		protected bool _canTakeDamage;

		public DamageableState DamageableState { get; private set; }

		#region Events

		public delegate void DamageableHandler();

		public event DamageableHandler OnBeforeDamageTaken;
		public event DamageableHandler OnDamageTaken;
		public event DamageableHandler OnAfterDamageTaken;
		public event DamageableHandler OnHealthBelowZero;
		public event DamageableHandler OnDeath;

		public event DamageableHandler OnRevive;

		#endregion

		protected virtual void Awake()
		{
			Initialize();
		}

		private void Start()
		{
			ChangeVulnerability(true);
		}

		private void OnDestroy()
		{
		}

		public virtual bool TryTakeDamage(float damage)
		{
			if (!_canTakeDamage) return false;
			OnBeforeDamageTaken?.Invoke();
			ProcessDamage(damage);
			OnAfterDamageTaken?.Invoke();
			return true;
		}

		public virtual void ChangeVulnerability(bool isVulnerable)
		{
			_canTakeDamage = isVulnerable;
		}

		protected virtual void ProcessDamage(float damage)
		{
			LoseHealth(damage);
			OnDamageTaken?.Invoke();

			if (_runtimeHealth <= 0)
			{
				OnHealthBelowZero?.Invoke();
				Die();
			}
		}

		protected virtual void Heal(float healAmount)
		{
			if (DamageableState == DamageableState.Dead) return;
			_runtimeHealth = Mathf.Min(_runtimeHealth + healAmount, _initialHealth);
		}

		private void LoseHealth(float damage)
		{
			_runtimeHealth -= damage;
		}
		

		protected virtual void Revive(bool maxHealth, float healAmount = 0)
		{
			DamageableState = DamageableState.Alive;
			ChangeVulnerability(true);
			if (maxHealth)
			{
				Heal(_initialHealth);
			}
			else
			{
				Heal(healAmount);
			}

			OnRevive?.Invoke();
		}
		
		protected virtual void Die()
		{
			ChangeVulnerability(false);
			DamageableState = DamageableState.Dead;
			_runtimeHealth = 0;
			OnDeath?.Invoke();
		}

		protected virtual void Initialize()
		{
			_initialHealth = _runtimeHealth;
			DamageableState = DamageableState.Alive;
		}

	}

	public enum DamageableState
	{
		Alive,
		Dead
	}
}