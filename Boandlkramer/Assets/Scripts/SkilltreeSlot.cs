using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class SkilltreeSlot : SkillSlot {

	Character character;
	CharacterData charData;


	void Start()
	{
		character = player.GetComponent<Character>();
		charData = character.data;
		UpdateSlot();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (skillInSlot.nextLevelSkill != null)
		{
			if (charData.SpendSkillPoint(skillInSlot))
			{
				skillInSlot = skillInSlot.nextLevelSkill;
				UpdateSlot();
				FindObjectOfType<SkilltreeUI>().UpdateSkilltreeUI();
				OnPointerEnter(eventData);
			}
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);

		if (infoCanvas != null)
		{
			// fill item data
			if (skillInSlot != null && textDescription != null && textManaCost != null)
			{
				textDescription.GetComponent<TextMeshProUGUI>().text += "\n \n" + "Level " + (skillInSlot.skillLevel + 1) + "\n"
					+ skillInSlot.descriptionNextLevel;

				// remove information again... not very elegant
				textManaCost.GetComponent<TextMeshProUGUI>().text = "";
			}
		}
	}


	#region DisableDragging
	public override void OnBeginDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}

	public override void OnDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		// these slots have no dragging
	}
	#endregion
}
