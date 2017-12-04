using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Skill", menuName = "Skills/Projectile (AOE)", order = 4)]
public class ProjectileAOESkill : OffensiveSkill {

	public float range = 1f;
	public float speed = 3f;
	public float AOERange = 0.5f;

	GameObject projectile;

	public override void Cast (Vector3 target, GameObject target_obj = null) {
		Vector3 _target = character.transform.position;
		_target = target;
		GameObject instance = Instantiate (projectile, character.transform.position, Quaternion.FromToRotation (Vector3.forward, target - character.transform.position));
		instance.GetComponent<Projectile> ().Initialize (_target, speed, damage, AOERange);
	}
}
