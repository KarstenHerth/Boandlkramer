using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Architect : MonoBehaviour {

	public int width = 10;
	public int height = 10;

	Map map;
	MapTile start;
	MapTile exit;

	public void GenerateMap () {
		map = new Map (width, height);

	}

	void AddStart (int x, int y) {
		start = map.tiles[x, y].MakeStart ();
	}

	void AddExit (int x, int y) {
		exit = map.tiles[x, y].MakeExit ();
	}

	void AddRoom () {

	}
}
