using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class DragDropWindow : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [SerializeField]
    Transform windowParent;

    Vector2 offset;

    void Start()
    {
        if (windowParent)
        {
            offset = this.transform.position - windowParent.position;
        }
        else
        {
            Debug.LogError("DragDropWindow needs assigned windowParent (Transform)");
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

    }



    public void OnDrag(PointerEventData eventData)
    {
        if (windowParent)
        {
            windowParent.position = eventData.position - offset;
        }
    }



    public void OnEndDrag(PointerEventData eventData)
    {


    }
}
