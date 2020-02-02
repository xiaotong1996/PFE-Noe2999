using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonContinueClicked : MonoBehaviour
{
    public GameObject exitCanvas;
    public void OnButtonContinue()
    {
        exitCanvas = GameObject.Find("ExitCanvas");
        Destroy(exitCanvas);
    }
}
