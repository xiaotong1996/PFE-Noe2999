using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SleepManager : MonoBehaviour
{

    public Image sleepBtnImage;
    public Image sleepImage;
    bool isSleep = false;
    float fadeSpeed = 1f;
    public RawImage rawImage;
    public RectTransform rectTransform;

    int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        rawImage.color = Color.clear;
        if (GameManager.Instance.IsSleep)
        {
            sleepImage.gameObject.SetActive(true);
            rawImage.gameObject.SetActive(true);
            rawImage.color = Color.black * 0.7f;
            //GameManager.Instance.IsSleep = true;
            sleepBtnImage.sprite = Resources.Load("Images/UI/sun", typeof(Sprite)) as Sprite;
            isSleep = true;
        }
        else
        {
            sleepImage.gameObject.SetActive(false);
            //GameManager.Instance.IsSleep = false;
            sleepBtnImage.sprite = Resources.Load("Images/UI/sleep", typeof(Sprite)) as Sprite;
            isSleep = false;
        }
    }
    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.Instance.IsSleep);
        if(flag == -1)
        {
            Debug.Log("flag-1 " + rawImage.color.a);
            FadeToClear();
            if (rawImage.color.a < 0.1f)
            {
                flag = 0;
                rawImage.color = Color.clear;
                //rawImage.gameObject.SetActive(false);
            }
        }
        else if(flag == 1)
        {
            Debug.Log("flag1 " + rawImage.color.a);
            FadeToBlack();

            if (rawImage.color.a > 0.7f)
            {
                flag = 0;
                //rawImage.color = Color.clear;
                //rawImage.gameObject.SetActive(false);
            }
        }
    }

    public void Click()
    {
        if (!AnimalDataModel.isPause)
        {
            if (!isSleep)
            {
                flag = 1;
                rawImage.color = Color.clear;
                rawImage.gameObject.SetActive(true);
                sleepImage.gameObject.SetActive(true);
                GameManager.Instance.IsSleep = true;
                sleepBtnImage.sprite = Resources.Load("Images/UI/sun", typeof(Sprite)) as Sprite;
                isSleep = true;
            }
            else
            {
                flag = -1;
                rawImage.gameObject.SetActive(true);
                sleepImage.gameObject.SetActive(false);
                GameManager.Instance.IsSleep = false;
                sleepBtnImage.sprite = Resources.Load("Images/UI/sleep", typeof(Sprite)) as Sprite;
                isSleep = false;
            }
        }
        
    }
}
