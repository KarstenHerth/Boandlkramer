using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SkillSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public GameObject player;

	// skill stored in this slot
	// protected Item item;

	// index of this slot
	[SerializeField]
	int index;

	// reference to the info panel to display
	[SerializeField]
	GameObject infoCanvas;

	[SerializeField]
	GameObject textSkillName;

	[SerializeField]
	GameObject textDescription;

	// for drag and drop
	[SerializeField]
	GameObject dragObject;

	Vector3 startPosition;
	Transform startParent;

	// slot that is being dragged. -1 if not dragging anything
	public static int dragSlotIndex = -1;

	// slot we are currently pointing at
	public static int currentHoverSlotIndex = -1;



	void Start()
	{

	}

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
		if (infoCanvas != null)
		{
			infoCanvas.SetActive(true);
			// adjust info box position
			Vector3 pos = transform.position;
			pos.x += GetComponent<RectTransform>().rect.width / 2;
			pos.y += GetComponent<RectTransform>().rect.height / 2 + infoCanvas.GetComponent<RectTransform>().rect.height;

			infoCanvas.transform.position = pos;

			// store slot we are hovering right now
			currentHoverSlotIndex = index;
		}

		// fill item data
		if (textSkillName != null && textDescription != null)
		{
			textSkillName.GetComponent<TextMeshProUGUI>().text = "Skill Name - " + this.name;
			textDescription.GetComponent<TextMeshProUGUI>().text = "Skill description - " + this.name;
		}


	}

	// Mouse has left the slot
	public void OnPointerExit(PointerEventData eventData)
	{
		// hide description of skill
		if (infoCanvas != null)
		{
			infoCanvas.SetActive(false);
		}

		// not pointing at a skill slot anymore
		currentHoverSlotIndex = -1;
	}


	public void OnBeginDrag(PointerEventData eventData)
	{
		// use image for the spell stored in this slot
		dragObject.SetActive(true);
		dragObject.GetComponentsInChildren<Image>()[1].sprite = GetComponentsInChildren<Image>()[1].sprite;
		dragSlotIndex = index;
		startPosition = transform.position;
		startParent = transform.parent;
		//GetComponent<CanvasGroup>().blocksRaycasts = false; 

	}



	public void OnDrag(PointerEventData eventData)
	{

		dragObject.transform.position = eventData.position;

	}



	public void OnEndDrag(PointerEventData eventData)
	{

		if (currentHoverSlotIndex > -1)
		{
			Debug.Log("Switch skill from slot " + dragSlotIndex + " with skill from slot " + currentHoverSlotIndex);
		}

		dragObject.SetActive(false);
		// end dragging
		dragSlotIndex = -1;

	}


	public virtual void OnRightClick()
	{
		// ?
	}
	public virtual void OnLeftClick()
	{
		// assign skill as active
		Debug.Log("CLICKED SKILL SLOT: " + this.name);
		
	}



}
