using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "NPCs/Enemy", order = 1)]
public class EnemyType : ScriptableObject {

	public int health = 100;
	public int mana = 100;

	[HideInInspector]
	public int strength = 0;
	[HideInInspector]
	public int dexterity = 0;
	[HideInInspector]
	public int intelligence = 0;
	[HideInInspector]
	public int vitality = 0;

	public int damage = 10;
	public float speed = 10f;
	public int armor = 2;

    public int level = 1;

    public Item[] loot;
}
