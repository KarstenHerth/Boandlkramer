using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Enemy : Character {

	Item[] loot;
	[SerializeField]
	EnemyType enemyType;

	void Start()
	{
		if (enemyType != null)
		{
			LoadCharacterData();
		}
	}

	void LoadCharacterData()
	{
		data.attributes["strength"].SetBase(enemyType.strength);
		data.attributes["dexterity"].SetBase(enemyType.dexterity);
		data.attributes["intelligence"].SetBase(enemyType.intelligence);
		data.attributes["vitality"].SetBase(enemyType.vitality);

		data.stats["health"] = new Stat(enemyType.health, data.attributes["vitality"]);
		data.stats["mana"] = new Stat(enemyType.mana, data.attributes["intelligence"]);

		data.baseDamage = enemyType.damage;
		data.baseSpeed = enemyType.speed;
		data.baseArmor = enemyType.armor;
        data.level = enemyType.level;

        loot = enemyType.loot;
	}

    protected override int CalculateDamage(Character other) {

        return data.baseDamage;
    }

    protected override float CalculateAttackSpeed() {

        return 10f / (data.baseSpeed + 10f);
    }

    protected override int ReducedDamage(int damage, DamageType dmgType = DamageType.None) {

        return damage - data.baseArmor;
    }

	protected override void Death () {

		// increase xp of the player
		foreach (Character character in charactersGainingXPFromThisCharacter) {
			character.data.IncreaseExperience (this.data.XPDropping ());
		}

		DropLoot ();

		Destroy (gameObject);
	}

	void DropLoot () {

		loot[Random.Range (0, loot.Length)].Spawn (transform.position);
	}
}
