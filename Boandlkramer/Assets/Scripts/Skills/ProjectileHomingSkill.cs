using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Skill", menuName = "Skills/Projectile (Homing)", order = 4)]
public class ProjectileHomingSkill : OffensiveSkill {

	public float range = 1f;
	public float speed = 3f;

	GameObject projectile;

	public override void Cast (Vector3 target, GameObject target_obj = null) {
		Vector3 _target = character.transform.position;
		_target = target;
		GameObject instance = Instantiate (projectile, character.transform.position, Quaternion.FromToRotation (Vector3.forward, target - character.transform.position));
		instance.GetComponent<HomingProjectile> ().Initialize (target_obj, speed, damage);
	}
}
