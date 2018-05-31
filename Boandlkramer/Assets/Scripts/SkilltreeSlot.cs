using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkilltreeSlot : SkillSlot {

	public override void OnLeftClick()
	{
		Debug.Log("Clicked on SkilltreeSlot!");
		// learn / upgrade this skill
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}

	public void OnDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}
}
