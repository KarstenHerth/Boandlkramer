using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : MonoBehaviour {

	GameObject _target;
	int _dmg;
	float _speed;

	public GameObject impact;

	Collider targetCollider;

	IEnumerator move;

	private void OnTriggerEnter (Collider collider) {
		if (collider == targetCollider) {
			Destroy (targetCollider.gameObject);
			Explode ();
		}
	}

	public void Initialize (GameObject target, float speed, int damage) {

		_dmg = damage;
		_speed = speed;

		_target = target;
	}

	void Explode () {
		GameObject instance = Instantiate (impact, transform.position, Quaternion.identity) as GameObject;
		Destroy (instance, 3f);
		Destroy (gameObject);
	}

	IEnumerator Move () {
		while (true) {
			Vector3 direction = _target.transform.position - transform.position;
			GetComponent<Rigidbody> ().velocity = new Vector3 (direction.x, 0f, direction.z).normalized * _speed;
		}
	}
}
