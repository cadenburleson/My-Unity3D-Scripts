using UnityEngine;
using System.Collections;

	public interface IDamageable<T>	{
		void Damage(T damageAmount);
	}

	public interface IHealable<T> {
		void Heal(T healthAmount);
	}

	
	