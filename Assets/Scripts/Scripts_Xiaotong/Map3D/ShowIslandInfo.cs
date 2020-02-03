using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// ShowIslandInfo is used to show the islandinfo canvas when player choose an island.
/// </summary>
public class ShowIslandInfo : MonoBehaviour
{
    private GameObject vaisseau;

    private GameObject uiPrefab;

    private GameObject ui;

    private RaycastHit hit;

    private GameObject island;

    private bool buttonClicked;

    private string islandDestinationName;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public string IslandDestinationName { get => islandDestinationName; set => islandDestinationName = value; }

    // Start is called before the first frame update
    void Start()
    {
        uiPrefab = Resources.Load<GameObject>("Prefabs/UI/Map/IslandInfo");

        //ui = gameObject.transform.GetChild(0).gameObject;

        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();


        vaisseau = GameObject.FindGameObjectWithTag("Vaisseau");
    }


    /// <summary>
    /// when detecting player's input form android platform and general platform, we need to use different functions.
    /// </summary>
    void Update()
    {

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
                    if (result.gameObject.name == "Button_OK" && !buttonClicked)
                    {
                        OnButtonOKClicked();
                        buttonClicked = true;
                    }
                    if (result.gameObject.name == "Button_Cancel")
                    {
                        ui.SetActive(false);
                    }

                }

            }
            else
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {


                    if (hit.transform.tag == "Island")
                    {
                        island = hit.transform.gameObject;
                    }
                    else
                    {
                        island = null;
                    }


                }

            }
        }
#endif



        if (Input.GetMouseButtonDown(0))
        {

            if (EventSystem.current.currentSelectedGameObject != null && EventSystem.current.IsPointerOverGameObject())
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
                    if (result.gameObject.name == "Button_OK" && !buttonClicked)
                    {
                        OnButtonOKClicked();
                        buttonClicked = true;
                    }
                    if (result.gameObject.name == "Button_Cancel")
                    {
                        ui.SetActive(false);
                    }

                }

            }
            else
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {


                    if (hit.transform.tag == "Island")
                    {
                        island = hit.transform.gameObject;
                    }
                    else
                    {
                        island = null;
                    }
                }
            }
        }

        var IslandChosenName = vaisseau.GetComponent<MoveOnEarth>().IslandChosenName;
        if (island != null && island.GetComponent<Destination>().Name == IslandChosenName)
        {

            if (vaisseau != null && island.GetComponent<Destination>().Name.Equals(vaisseau.GetComponent<CheckArrived>().IslandStayName))
            {
                if (ui != null)
                {
                    ui.SetActive(false);
                }
            }
            else
            {
                if (vaisseau != null && !vaisseau.GetComponent<MoveOnEarth>().IsMove)
                {
                    if (ui == null)
                    {
                        ui = Instantiate(uiPrefab);
                        ui.transform.SetParent(gameObject.GetComponent<Transform>(), false);
                        ui.transform.position = island.transform.position;

                        var ecosystemIcon = ui.transform.GetChild(2).gameObject;
                        var ecosystemTitle = ui.transform.GetChild(1).gameObject;

                        var destination = island.GetComponent<Destination>();

                        ChangeImage(ecosystemIcon, destination.Ecosysteme.EcosystemeType);
                        //ChangeTitle(ecosystemTitle, destination.Ecosysteme.EcosystemeType);
                    }
                    else
                    {
                        var ecosystemIcon = ui.transform.GetChild(2).gameObject;
                        var ecosystemTitle = ui.transform.GetChild(1).gameObject;

                        var destination = island.GetComponent<Destination>();

                        ChangeImage(ecosystemIcon, destination.Ecosysteme.EcosystemeType);
                        //ChangeTitle(ecosystemTitle, destination.Ecosysteme.EcosystemeType);

                        ui.transform.position = island.transform.position;
                        ui.SetActive(true);
                    }
                }

            }



        }
        else
        {
            if (buttonClicked)
            {
                OnButtonOKClicked();
            }
            else
            {
                if (ui != null)
                {
                    ui.SetActive(false);
                }
            }

        }
    }

    /// <summary>
    /// Useless cause we don't want to show any text.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="ecosystemeType"></param>
    public void ChangeTitle(GameObject title, EcosystemeType ecosystemeType)
    {
        var component = title.GetComponent<Text>();
        switch (ecosystemeType)
        {
            case EcosystemeType.FORET:
                component.text = "FORET";
                break;
            case EcosystemeType.DESERT:
                component.text = "DESERT";
                break;
            case EcosystemeType.NEIGE:
                component.text = "NEIGE";
                break;
            case EcosystemeType.PLAINE:
                component.text = "PLAINE";
                break;
            case EcosystemeType.SAVANE:
                component.text = "SAVANE";
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Change the image accroding to EcosystemeType
    /// </summary>
    /// <param name="image"></param>
    /// <param name="ecosystemeType"></param>
    public void ChangeImage(GameObject image, EcosystemeType ecosystemeType)
    {
        var component = image.GetComponent<Image>();
        switch (ecosystemeType)
        {
            case EcosystemeType.FORET:
                component.sprite = Resources.Load<Sprite>("Images/IslandInfo/foresticon");
                break;
            case EcosystemeType.DESERT:
                component.sprite = Resources.Load<Sprite>("Images/IslandInfo/deserticon");
                break;
            case EcosystemeType.NEIGE:
                component.sprite = Resources.Load<Sprite>("Images/IslandInfo/snowicon");
                break;
            case EcosystemeType.PLAINE:
                component.sprite = Resources.Load<Sprite>("Images/IslandInfo/Paysage_plaine_icone");
                break;
            case EcosystemeType.SAVANE:
                component.sprite = Resources.Load<Sprite>("Images/IslandInfo/Paysage_savane_icone");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Useless we don't need a cancal button
    /// </summary>
    public void OnButtonCancelClicked()
    {
        if (ui != null)
            ui.SetActive(false);
    }

    /// <summary>
    /// Respond when player chooses an island.
    /// </summary>
    public void OnButtonOKClicked()
    {

        var component = vaisseau.GetComponent<MoveOnEarth>();
        component.ChangeIsMove();

        //IslandDestinationName = island.GetComponent<Destination>().Name;
        buttonClicked = false;
        if (ui != null)
            ui.SetActive(false);
    }
}
