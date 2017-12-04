﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Skill", menuName = "Skills/Targeted", order = 2)]
public class TargetedSkill : OffensiveSkill {

	public float range = 1f;
	public float AOERange = 0.5f;
	public bool isInstant;
	public bool isAOE;
	public bool isHoming;

	GameObject projectile;

	public override void Cast (Vector3 target, GameObject target_obj = null) {
		Vector3 _target = character.transform.position;
		_target = target;
		GameObject instance = Instantiate (projectile, character.transform.position, Quaternion.FromToRotation (Vector3.forward, target - character.transform.position));
		instance.GetComponent<Projectile> ().Initialize (_target, 3f, damage, AOERange);
	}
}
