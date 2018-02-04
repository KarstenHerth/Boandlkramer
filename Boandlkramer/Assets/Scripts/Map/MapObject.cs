using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

	public void ControlVisibility (Camera camera) {
		Vector2 v1 = (new Vector2 (camera.transform.forward.x, camera.transform.forward.z)).normalized;
		Vector2 v2 = (new Vector2 (-transform.forward.x, -transform.forward.z)).normalized;
		bool b = !(Vector2.Dot (v1, v2) > 0.7);
		MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer> ();
		foreach(MeshRenderer r in renderers) {
			r.enabled = b;
		}
	}
}
