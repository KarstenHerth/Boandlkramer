using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	MapGenerator mapGenerator;
	[SerializeField]
	Character player;
	[SerializeField]
	GameObject[] enemies;

	public void Spawn (int n) {

		List<Tile> locations = new List<Tile> (mapGenerator.map);

		locations.RemoveAt (0);

		for (int i = 0; i < n; i++) {

			Tile location = locations[Random.Range (0, locations.Count)];
			GameObject instance = Instantiate (enemies[Random.Range (0, enemies.Length)], location.spawn.transform.position, Quaternion.identity);
			instance.GetComponent<Character> ().charactersGainingXPFromThisCharacter = new Character[] { player };
			locations.Remove (location);
		}
	}
}
