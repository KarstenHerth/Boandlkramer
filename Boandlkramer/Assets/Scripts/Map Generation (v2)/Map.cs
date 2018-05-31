using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {

	public int width, height;
	public MapTile[,] tiles;

	public Map (int c_width, int c_height) {

		width = c_width;
		height = c_height;
		tiles = new MapTile[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				tiles[i, j] = new EmptyTile (i, j);
			}
		}
	}
}
