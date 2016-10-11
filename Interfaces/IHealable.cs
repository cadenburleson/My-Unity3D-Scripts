using UnityEngine;
using System.Collections;

public interface IHealable<T> {
	void Heal(T healthAmount);
}
