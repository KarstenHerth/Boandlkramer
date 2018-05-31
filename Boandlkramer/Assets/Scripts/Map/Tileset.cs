using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Tileset", menuName = "Map/Tileset", order = 1)]
public class Tileset : ScriptableObject {

	public GameObject[] floor;
	public GameObject[] wall;
	public GameObject[] door;
	public GameObject[] column;

	public GameObject GetFloor () {
		return floor[Random.Range(0, floor.Length-1)];
	}

	public GameObject GetWall () {
		return wall[Random.Range (0, wall.Length - 1)];
	}

	public GameObject GetDoor () {
		return door[Random.Range (0, door.Length - 1)];
	}

	public GameObject GetColumn () {
		return column[Random.Range (0, column.Length - 1)];
	}
}
