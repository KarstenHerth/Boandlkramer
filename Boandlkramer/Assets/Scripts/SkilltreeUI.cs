using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkilltreeUI : MonoBehaviour {

	public GameObject skilltreeUI;

	// reference to the player object
	public GameObject player;

	CharacterData charData;
	Character character;

	public TextMeshProUGUI textPoints;

	void Start()
	{
		// safe character data for quick access
		charData = player.GetComponent<Character>().data;
		character = player.GetComponent<Character>();

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
				SkilltreeSlot[] slots = skilltreeUI.GetComponentsInChildren<SkilltreeSlot>();
				foreach (var slot in slots)
				{
					slot.UpdateSlot();
				}
				skilltreeUI.GetComponent<Canvas>().sortingOrder = UICanvasSorting.sorting++;

				UpdateSkilltreeUI();
			}
		}
	}

	public void UpdateSkilltreeUI()
	{
		int remaining = charData.GetRemainingSkillPoints();
		textPoints.text = remaining.ToString();
	}
}
