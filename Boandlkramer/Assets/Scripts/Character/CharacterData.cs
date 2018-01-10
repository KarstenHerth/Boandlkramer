
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData {

    public int level = 1;

    // Attribute points per level
    public int attributePointsPerLevel = 5;

	public Dictionary<string, Stat> stats;
	public Dictionary<string, Attribute> attributes;
	public List<Perk> perks;

    public int baseDamage = 3;
    public float baseSpeed = 10f;
    public int baseArmor = 0;

    // current XP the character has
	int experience = 0;

    // remaining attribute points to spend
    int remainingAttributePoints = 0;

    // for updating UI
    public CharacterUI charUI;

	public CharacterData () {

        attributes = new Dictionary<string, Attribute>() { { "strength", new Attribute ()}, { "dexterity", new Attribute ()},
            { "vitality", new Attribute ()}, { "intelligence", new Attribute ()} };
        stats = new Dictionary<string, Stat> () { { "health", new Stat (100, attributes["vitality"]) },
			{ "mana", new Stat (100, attributes["intelligence"]) } };
		perks = new List<Perk> ();

	}

    // for UI
	public int GetCurrentExperiencePoints()
	{
		return experience;
	}

    // calculates the amount of xp needed for a certain level
	public int CalculateExperienceForLevel(int lvl)
	{
		if (lvl == 1)
			return 0;
		else
			return 100*(lvl * lvl);
	}

    // adds an amount of XP points and increases the level if enough xp was gained
	public void IncreaseExperience(int expAmount)
	{
		experience += expAmount;

        // adjust the level
		if (experience >= CalculateExperienceForLevel(level + 1))
		{
			level++;
            stats["health"].Current = stats["health"].Max;
            stats["mana"].Current = stats["mana"].Max;
            remainingAttributePoints += attributePointsPerLevel;

            // this is for testing if we gained that much experience to level up more than one level
            IncreaseExperience(0);
		}

		if (charUI != null)
			charUI.UpdateCharacterUI();
	}

    // for UI
    public int GetRemainingAttributePoints()
    {
        return remainingAttributePoints;
    }

    // increases an attribute if possible
    public void SpendAttributePoint(string attribute)
    {
        if (remainingAttributePoints > 0)
        {
            attributes[attribute].IncreaseBase();
            remainingAttributePoints--;
        }
    }

    // calculates the amount of XP this character "drops" if he dies
    public int XPDropping()
    {
        return level * 1000;
    }
	
}

[System.Serializable]
public class Stat {

	int m_max;
	int m_current;
    Attribute m_attribute;

	public int Max {
		get {
            if (m_attribute != null)
                return m_max + m_attribute.GetValue() * 10;
            else
                return m_max;
		}
		set {
			if (value >= 0)
				m_max = value;
		}
	}

	public int Current {
		get {
			return m_current;
		}
		set {
            m_current = Mathf.Clamp(value, 0, Max);
;		}
	}

	public Stat () {

		m_max = 100;
        m_attribute = null;
		m_current = Max;
	}

	public Stat (int max, Attribute attribute) {

		m_max = Mathf.Clamp(max, 0, int.MaxValue);
        m_attribute = attribute;
		m_current = Max;
	}

	public Stat (int max, int current, Attribute attribute) {

		m_max = Mathf.Clamp (max, 0, int.MaxValue);
		m_attribute = attribute;
		m_current = Mathf.Clamp(current, 0, Max);
    }
}

[System.Serializable]
public class Attribute {

	int m_base;
	List<AttributeModifier> modifiers = new List<AttributeModifier> ();

	public Attribute () {

		m_base = 5;
	}

	public Attribute (int value) {

		m_base = value;
	}

	public int GetValue () {

		int value = m_base;
		foreach (AttributeModifier modifier in modifiers)
			value += modifier.amount;
		return value;
	}

	public int GetBaseValue()
	{
		return m_base;
	}

	public int GetModifierValue()
	{
		int value = 0;
		foreach (AttributeModifier modifier in modifiers)
			value += modifier.amount;

		return value;
	}

	public void SetBase (int value) {

		if (value >= 0)
			m_base = value;
	}

	public void AddModifier (AttributeModifier modifier) {

		modifiers.Add (modifier);
	}

	public void RemoveModifier (AttributeModifier modifier) {

		modifiers.Remove (modifier);
	}

    public void IncreaseBase()
    {
        m_base++;
    }
}
