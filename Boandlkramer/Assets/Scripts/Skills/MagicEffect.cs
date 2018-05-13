using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicEffect", menuName = "MagicEffect/MagicEffect", order = 1)]
public class MagicEffect : ScriptableObject {


	// time this effect lasts on the character
	public float totalTime = 3f;

	// effect on different stats of the character
	public float movementMultiplier = 1f;
	public float damageMultiplier = 1f;
	public int damageOverTime = 0;

	// public ParticleSystem particleEffect;
}
