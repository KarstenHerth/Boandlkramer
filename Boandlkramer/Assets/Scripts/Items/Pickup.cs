using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable {

    public Item item;

    public override void Interact(Character other)
    {
        Debug.Log("Picking up " + item.name);
        Debug.Log("Description: " + item.description);


        // Add the item to the inventory if possible
        if (Inventory.instance.Add(item))
        {
            DestroyObject(this.gameObject);
        }
    }
}
