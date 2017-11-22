using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

	public GameObject player;

	// skill stored in this slot
	// protected Item item;

	// reference to the info panel to display
	[SerializeField]
	GameObject infoCanvas;

	[SerializeField]
	GameObject textSkillName;

	[SerializeField]
	GameObject textDescription;


	public void AddItem(Item newItem)
	{

	}

	public void ClearSlot()
	{

	}


	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			if (eventData.clickCount == 1)
				OnLeftClick();
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			OnRightClick();
		}

	}

	// On Mouse over event for this slot
	public void OnPointerEnter(PointerEventData eventData)
	{
		// show info box
		infoCanvas.SetActive(true);

		// fill item data
		textSkillName.GetComponent<TextMeshProUGUI>().text = "Skill Name - " + this.name;
		textDescription.GetComponent<TextMeshProUGUI>().text = "Skill description - " + this.name;


		// adjust info box position
		Vector3 pos = transform.position;
		pos.x += GetComponent<RectTransform>().rect.width / 2;
		pos.y += GetComponent<RectTransform>().rect.height / 2 + infoCanvas.GetComponent<RectTransform>().rect.height;

		infoCanvas.transform.position = pos;
	}

	// Mouse has left the slot
	public void OnPointerExit(PointerEventData eventData)
	{
		// hide description of skill
		infoCanvas.SetActive(false);
	}

	public virtual void OnRightClick()
	{
		// remove skill from slot
		// ThrowItemAway();
	}
	public virtual void OnLeftClick()
	{
		// assign skill as active
		Debug.Log("CLICKED SKILL SLOT: " + this.name);
		
	}



	protected void ThrowItemAway()
	{
		// remove skill from slot
	}

}
