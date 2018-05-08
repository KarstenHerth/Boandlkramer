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

	public GameObject castPoint;

    public Character[] charactersGainingXPFromThisCharacter;

    Inventory inventory;

	public bool canAttack = true;
	public bool canCast = true;

	// all skills the player may have
	public Skill[] skillbook;

	// all skills the player possesses at the moment
	public Skill[] availableSkills;

	// skill that is active right now
	public Skill activeSkill;

    void Start()
    {
		availableSkills = new Skill[skillbook.Length];
		for (int i=0; i < skillbook.Length; i++)
		{
			availableSkills[i] = Instantiate(skillbook[i]);
			availableSkills[i].name = skillbook[i].name;
			availableSkills[i].character = this;
		}
		activeSkill = availableSkills[0];
       // activeSkill.character = this;
        inventory = GetComponent<Inventory>();

		FindObjectOfType<SkillbarUI>().FillSkillSlots();
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
		if (canCast) {
			if (other != null) {
				if (activeSkill.CastCheck (target, other.gameObject)) {
					StartCoroutine (Cast (target, other, 0.33f));
					if (GetComponent<BoandlAnimation> () != null)
						GetComponent<BoandlAnimation> ().Trigger ("Cast");
				}
			}
			else {
				if (activeSkill.CastCheck (target, null)) {
					StartCoroutine (Cast (target, other, 0.33f));
					if (GetComponent<BoandlAnimation> () != null)
						GetComponent<BoandlAnimation> ().Trigger ("Cast");

				}
			}	
		}
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

	// Calculates the chance for a critical hit of this character on a character of level "levelOther"
	public int CalculateCrit(int levelOther)
	{
		return (data.attributes["dexterity"].GetValue() - 2 - 2 * levelOther);
	}

	public int GetDamage(int otherLevel)
	{
		int wpnDamage;
		Weapon wpn = (Weapon)inventory.equipment[EquipLocation.Hands];
		if (wpn != null)
		{
			wpnDamage = wpn.damage;
		}
		else
		{
			wpnDamage = data.baseDamage;
		}

		return (int)((wpnDamage + data.attributes["strength"].GetValue()));
	}
	protected virtual int CalculateDamage(Character other)
    {
		int dmg =  GetDamage(other.data.level);
		int critMult = 1;
		int rng = (int)Random.Range(0, 100);

		// 2: Attribute base - 1 - 2, 2: Depends on attribute points per level
		if (rng < 10 * CalculateCrit(other.data.level))
		{
			Debug.Log("CRIT!");
			critMult = 2;
		}

		return dmg * critMult;
	}
	
	public float GetAttackSpeed()
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

    protected virtual float CalculateAttackSpeed()
    {
		return GetAttackSpeed();
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

	IEnumerator Cast (Vector3 target, Character other, float amount) {
		canCast = false;
		yield return new WaitForSeconds (amount);
		if (other != null)
			activeSkill.Cast (target, other.gameObject);
		else
			activeSkill.Cast (target, null);
		canCast = true;
	}
}
