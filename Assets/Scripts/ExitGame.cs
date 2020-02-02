using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public static ExitGame Instance;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    private GameObject exitCanvasPrefab;
    private GameObject exitCanvas;
    // Start is called before the first frame update
    void Start()
    {
        exitCanvasPrefab = Resources.Load<GameObject>("Prefabs/UI/ExitCanvas");

        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                exitCanvas = Instantiate(exitCanvasPrefab);
            }
        }


#if true  //UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0)
        {

            if (EventSystem.current.currentSelectedGameObject != null && ClickIsOverUI.Instance.IsPointerOverUIObject(Input.GetTouch(0).fingerId))
            {

                //Debug.Log(EventSystem.current.currentSelectedGameObject.gameObject.name);
                //Set up the new Pointer Event
                m_PointerEventData = new PointerEventData(m_EventSystem);
                //Set the Pointer Event Position to that of the mouse position
                m_PointerEventData.position = Input.mousePosition;

                //Create a list of Raycast Results
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                m_Raycaster.Raycast(m_PointerEventData, results);


                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    if (result.gameObject.name == "Quit")
                    {
                        Application.Quit();
                    }
                    if (result.gameObject.name == "Continue")
                    {
                        exitCanvas.SetActive(false);
                    }

                }

            }
            else
            {
                exitCanvas.SetActive(false);
            }
        }
#endif
    }

}
