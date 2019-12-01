using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridUI : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static Action<Transform> OnLeftBeginDrag;
    public static Action<Transform, Transform> OnLeftEndDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftBeginDrag != null)
                OnLeftBeginDrag(transform);
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(OnLeftEndDrag != null)
            {
                if (eventData.pointerEnter == null)
                    OnLeftEndDrag(transform, null);
                else
                    OnLeftEndDrag(transform, eventData.pointerEnter.transform);
            }
        }
        
    }

   
}
