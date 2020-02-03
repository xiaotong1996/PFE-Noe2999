using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ClickIsOverUI is a tool class used for android touch input.
/// </summary>
public class ClickIsOverUI
{

    public static ClickIsOverUI Instance = new ClickIsOverUI();

    public ClickIsOverUI()
    { }

    /// <summary>
    /// Method 1. Override eventsystem function
    /// </summary>
    /// <param name="fingerID"></param>
    /// <returns></returns>
    // int id = Input.GetTouch(0).fingerId;
    public bool IsPointerOverUIObject(int fingerID)
    {
        return EventSystem.current.IsPointerOverGameObject(fingerID);
    }

    /// <summary>
    /// Method 2. unused
    /// </summary>
    /// <param name="screenPosition"></param>
    /// <returns></returns>
    public bool IsPointerOverUIObject(Vector2 screenPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(screenPosition.x, screenPosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    /// <summary>
    /// Method 3. unsed. use GraphicRaycaster
    /// </summary>
    /// <param name="canvas"></param>
    /// <param name="screenPosition"></param>
    /// <returns></returns>
    public bool IsPointerOverUIObject(Canvas canvas, Vector2 screenPosition)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = screenPosition;
        GraphicRaycaster uiRaycaster = canvas.gameObject.GetComponent<GraphicRaycaster>();

        List<RaycastResult> results = new List<RaycastResult>();
        uiRaycaster.Raycast(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}

