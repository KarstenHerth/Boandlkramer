using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public void ClickQuitGame()
	{
		Debug.Log("Quit Game");
		Application.Quit();
	}

	public void ClickNewGame()
	{
		Debug.Log("New Game");
	}
}
