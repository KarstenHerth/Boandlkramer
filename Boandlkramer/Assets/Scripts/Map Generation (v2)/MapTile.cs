using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile {

	public enum Tag { None, Start, Exit};
	public Tag tag;
	public int x, y;

	public MapTile(int c_x, int c_y) {
		x = c_x;
		y = c_y;
	}

	public MapTile MakeStart () {
		tag = Tag.Start;
		return this;
	}

	public MapTile MakeExit () {
		tag = Tag.Exit;
		return this;
	}
}

public class EmptyTile : MapTile {

	public EmptyTile(int c_x, int c_y) : base (c_x, c_y) {

	}
}

public class FloorTile : MapTile {

	public FloorTile (int c_x, int c_y) : base (c_x, c_y) {

	}
}

public class WallTile : MapTile {

	public enum Direction { None, N, E, S, W, NE, SE, SW, NW };
	public Direction direction;

	public WallTile (int c_x, int c_y, Direction c_direction) : base (c_x, c_y) {
		direction = c_direction;
	}
}

public class DoorTile : MapTile {

	public enum Direction { None, N, E, S, W};
	public Direction direction;

	public DoorTile (int c_x, int c_y, Direction c_direction) : base (c_x, c_y) {
		direction = c_direction;
	}
}
