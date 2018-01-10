using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;


public class AttributeSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // specify the attribute of this slot ["strength", "vitality", "dexterity", "intelligence"]
    public string attribute;

    [SerializeField]
    string description;

    // reference to the info panel to display
    [SerializeField]
    GameObject infoCanvas;

    [SerializeField]
    GameObject textAttributeName;

    [SerializeField]
    GameObject textDescription;

	[SerializeField]
	GameObject textEffect;


    // reference to the player object
    [SerializeField]
    GameObject player;

    //CharacterData charData;

    void Start()
    {
        // safe character data for quick access
        //charData = player.GetComponent<Character>().data;

    }

    // On Mouse over event for this slot
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Show description of item if there is any
        if (attribute != "")
        {
            // show info box
            infoCanvas.SetActive(true);

            // fill item data
            textAttributeName.GetComponent<TextMeshProUGUI>().text = attribute.Remove(1).ToUpper() + attribute.Substring(1);
            textDescription.GetComponent<TextMeshProUGUI>().text = description;


            // adjust info box position
            Vector3 pos = transform.position;
            pos.x += GetComponent<RectTransform>().rect.width / 2;
            pos.y += GetComponent<RectTransform>().rect.height / 2 + infoCanvas.GetComponent<RectTransform>().rect.height;

            infoCanvas.transform.position = pos;

        }
    }

    // Mouse has left the slot
    public void OnPointerExit(PointerEventData eventData)
    {
        // hide description of item
        infoCanvas.SetActive(false);
    }

}