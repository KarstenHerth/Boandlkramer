﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	[SerializeField]
	Character player;
	[SerializeField]
	PlayerController playerController;

	[SerializeField]
	Slider playerHealth;
	[SerializeField]
	Slider playerMana;
	[SerializeField]
	Slider enemyHealth;

	void Update () {

		playerHealth.value = (float) player.data.stats["health"].Current / (float) player.data.stats["health"].Max;
		playerMana.value = (float) player.data.stats["mana"].Current / (float) player.data.stats["mana"].Max;

		if (playerController.focus != null) {

			enemyHealth.gameObject.SetActive (true);
			enemyHealth.value = (float) playerController.focus.data.stats["health"].Current / (float) playerController.focus.data.stats["health"].Max;
		}
		else {

			enemyHealth.gameObject.SetActive (false);
		}
	}
}
