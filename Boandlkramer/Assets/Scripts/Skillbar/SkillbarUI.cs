
using TMPro;
using UnityEngine;

public class SkillbarUI : MonoBehaviour {

	// number keycodes for skill selection
	private KeyCode[] keyCodes = {
		 KeyCode.Alpha1,
		 KeyCode.Alpha2,
		 KeyCode.Alpha3,
		 KeyCode.Alpha4,
		 KeyCode.Alpha5,
		 KeyCode.Alpha6,
		 KeyCode.Alpha7,
		 KeyCode.Alpha8,
		 KeyCode.Alpha9,
		 KeyCode.Alpha0
	 };

	// quick reference to the inventory
	Inventory inventory;

    // for reference the player and access character data
    public Transform Player;
    CharacterData playerData;

	// reference to skill parent from skill bar
	[SerializeField]
	Transform skillParent;

	SkillSlot[] skillSlots;


    // Text for counting health potions
    public Transform textHealthParent;
    private TextMeshProUGUI textHealthPotions;

    // Text for counting mana Potions
    public Transform textManaParent;
    private TextMeshProUGUI textManaPotions;

    // Use this for initialization
    void Start () {

        // reference to the inventory for accessing number of potions the player possesses
        inventory = Inventory.instance;
        inventory.potionsHaveChangedCallback += UpdateSkillbarUI;

        textHealthPotions = textHealthParent.GetComponent<TextMeshProUGUI>();
        textManaPotions = textManaParent.GetComponent<TextMeshProUGUI>();

		// reference to player data in order to manipulate health etc.
        playerData = Player.GetComponent<Character>().data;

		// reference to skill slots
		skillSlots = skillParent.GetComponentsInChildren<SkillSlot>();

		Debug.Log(skillSlots.Length.ToString());
    }

	// Update is called once per frame
	void Update()
	{

		// check input for consuming potions
		if (Input.GetKeyDown(KeyCode.R))
		{
			UseManaPotion();
		}
		else if (Input.GetKeyDown(KeyCode.Q))
		{
			UseHealthPotion();
		}

		// input for skill selection
		for (int i = 0; i < keyCodes.Length; i++)
		{
			if (Input.GetKeyDown(keyCodes[i]))
			{
				// call click routine of skill slot in order to activate the corresponding skill as active skill
				if (i < skillSlots.Length)
				{
					skillSlots[i].OnLeftClick();
				}
			}

		}
	}

    void UpdateSkillbarUI()
    {
        // update number of potions available to the player
        textHealthPotions.text = inventory.healthPotions.ToString();
        textManaPotions.text = inventory.manaPotions.ToString();
    }

    void UseHealthPotion()
    {
		// consumes a health potion and adds 20% of max health to the player
        if (inventory.healthPotions > 0)
        {
            inventory.healthPotions--;
            playerData.stats["health"].Current +=(int)(0.2f * playerData.stats["health"].Max);
            UpdateSkillbarUI();
        }
    }

    void UseManaPotion()
    {
		// consumes a mana potion and adds 20% of max mana to the player
		if (inventory.manaPotions > 0)
        {
            inventory.manaPotions--;
            playerData.stats["mana"].Current += (int)(0.2f * playerData.stats["mana"].Max);
            UpdateSkillbarUI();
        }
    }
}
