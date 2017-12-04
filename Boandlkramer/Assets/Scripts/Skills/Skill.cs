using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "Skills/Skill (Base)", order = 1)]
public class Skill : ScriptableObject {

    public Sprite icon;
    public string description;

	public int manaCost = 10;

    public Character character;

    public virtual void Cast (Vector3 target, GameObject target_obj) {

		character.data.stats["mana"].Current -= manaCost;
	}
}
