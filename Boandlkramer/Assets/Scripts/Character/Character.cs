using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Character : MonoBehaviour {

	public CharacterData data = new CharacterData ();
	[SerializeField]
	GameObject ui;
	[SerializeField]
	TextMeshPro text;

    public Character[] charactersGainingXPFromThisCharacter;

    Inventory inventory;

	public bool canAttack = true;

	public Skill[] skillbook;
    public Skill activeSkill;

    void Start()
    {
        activeSkill = Instantiate(activeSkill);
        activeSkill.character = this;
        inventory = GetComponent<Inventory>();
    }

	public void Attack (Character other) {

		if (canAttack) {
            if(GetComponent<BoandlAnimation>()!=null)
                GetComponent<BoandlAnimation>().Trigger("Attack");
			StartCoroutine (AttackCooldown (CalculateAttackSpeed ()));
			other.TakeDamage (CalculateDamage(other));
		}
	}

    public void SecondaryAttack(Vector3 target, Character other)
    {
        activeSkill.Cast(target, other.gameObject);
    }

	public void TakeDamage (int amount, DamageType dmgType = DamageType.None) {

		int rd = ReducedDamage (amount, dmgType);
		if (ui != null && text != null) {
			TextMeshPro instance = Instantiate (text, ui.transform) as TextMeshPro;
			instance.text = rd.ToString ();
		}

		data.stats["health"].Current -= rd;

		if (data.stats["health"].Current <= 0)
			Death ();
	}

    protected virtual int CalculateDamage(Character other)
    {
        int wpnDamage;
        float critMult = 1f;
        Weapon wpn = (Weapon)inventory.equipment[EquipLocation.Hands];
        if (wpn != null)
        {
            wpnDamage = wpn.damage;
        }
        else
        {
            wpnDamage = data.baseDamage;
        }

        int rng = (int) Random.Range(0, 100);

        // 2: Attribute base - 1 - 2, 2: Depends on attribute points per level
        if (rng < 10 * (data.attributes["dexterity"].GetValue() - 2 - 2 * other.data.level))
        {
            Debug.Log("CRIT!");
            critMult = 2f;
        }

        return (int) ((wpnDamage + data.attributes["strength"].GetValue()) * critMult);
    }

    protected virtual float CalculateAttackSpeed()
    {
        float wpnSpeed;
        Weapon wpn = (Weapon)inventory.equipment[EquipLocation.Hands];
        if (wpn != null)
        {
            wpnSpeed = wpn.speed;
        }
        else
        {
            wpnSpeed = data.baseSpeed;
        }

        return 10f / (wpnSpeed + data.attributes["dexterity"].GetValue());
    }

    protected virtual int ReducedDamage (int damage, DamageType dmgType = DamageType.None)
    {
        int armAbs = 0;
        float armRel = 1f;

        EquipLocation[] loc = new EquipLocation[4] { EquipLocation.Chest, EquipLocation.Head, EquipLocation.Gloves, EquipLocation.Boots };

        for (int i = 0; i < 4; i++)
        {
            Armor arm = (Armor)inventory.equipment[loc[i]];
            if (arm != null)
            {
                armAbs += arm.absolut;
                armRel *= (1f - arm.relative);
            }
        }

        return (int) (Mathf.Clamp(damage - armAbs, 0, int.MaxValue) * armRel);
    }

	protected virtual void Death () {

		Destroy (gameObject);
	}

	IEnumerator AttackCooldown (float amount) {

		canAttack = false;

		yield return new WaitForSeconds (amount);

		canAttack = true;
	}
}
