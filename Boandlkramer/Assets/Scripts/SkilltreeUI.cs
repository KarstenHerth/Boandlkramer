using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilltreeUI : MonoBehaviour {

	public GameObject skilltreeUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// toggle visibility of inventory
		if (Input.GetButtonDown("Skilltree"))
		{
			if (skilltreeUI.activeSelf)
			{
				skilltreeUI.GetComponent<Canvas>().sortingOrder = 0;
				skilltreeUI.SetActive(false);
			}
			else
			{
				skilltreeUI.SetActive(true);
				skilltreeUI.GetComponent<Canvas>().sortingOrder = UICanvasSorting.sorting++;
			}
		}
	}
}
