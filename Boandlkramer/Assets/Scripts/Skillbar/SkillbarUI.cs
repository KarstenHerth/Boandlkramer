
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
	 };

	// quick reference to the inventory
	Inventory inventory;

    // for reference the player and access character data
    public Transform Player;
    CharacterData playerData;

	// reference to skill parent from skill bar
	[SerializeField]
	Transform skillParent;


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

        playerData = Player.GetComponent<Character>().data;
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
				int numberPressed = i + 1;
				Debug.Log(numberPressed);
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
        if (inventory.healthPotions > 0)
        {
            inventory.healthPotions--;
            playerData.stats["health"].Current += 20;
            UpdateSkillbarUI();
        }
    }

    void UseManaPotion()
    {
        if (inventory.manaPotions > 0)
        {
            inventory.manaPotions--;
            playerData.stats["mana"].Current += 20;
            UpdateSkillbarUI();
        }
    }
}
