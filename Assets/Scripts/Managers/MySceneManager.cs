using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{

    public GameObject menu;
     float fadeSpeed = 1.5f;
    public bool sceneStarting = true;
    public RawImage rawImage;
    public bool isEnd = false;
    string sceneName;
    public RectTransform rectTransform;
    void Awake()
    {
        //rawImage = GetComponent<RawImage>();
    }
    // Start is called before the first frame update
    void Start()
    {

        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        //Debug.Log("color" + rawImage.color.ToString());
       // Debug.Log("color" + Color.clear.ToString());
        //rawImage.color = Color.black;
        // menu = GameObject.FindGameObjectWithTag("Menu");
    }
    private void FadeToClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    private void FadeToBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {

        
        if(SceneDataModel.lastScene == "Introduction" || SceneDataModel.lastScene == "Start")
            MusicManager.Instance.MusicStop();
        FadeToClear();
        if (rawImage.color.a < 0.1f)
        {
            if (SceneDataModel.lastScene == "Introduction" || SceneDataModel.lastScene == "Start")
                MusicManager.Instance.PlayMusicByName("nature");
            rawImage.color = Color.clear;
            rawImage.enabled = false;
            sceneStarting = false;
        }
    }

     void EndScene(string name)
    {
        rawImage.gameObject.SetActive(true);
        FadeToBlack();
        if (rawImage.color.a > 0.95f)
        {
           // SceneManager.LoadScene(name);
        }
    }

    private void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (sceneStarting)
            StartScene();

        if (isEnd && sceneName != null)
            EndScene(sceneName);
    }


    public void MenuBtnClick()
    {
        SoundManager.Instance.PlayAudioByName("click");

        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            AnimalDataModel.isPause = false;
           
            Time.timeScale = 1;
        }
       else
        {
            menu.SetActive(true);
            AnimalDataModel.isPause = true;
            Time.timeScale = 0;
        }
        
    }

    public void IntroductionClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Introduction");
        SceneDataModel.flagForIntroduction = "menu";
        SceneDataModel.lastScene = SceneManager.GetActiveScene().name;
        SceneDataModel.curscene = "Introduction";
    }
    public void LoadScene(string  name)
    {
            if(name == "Introduction")
                SceneDataModel.flagForIntroduction = "play";
        AnimalDataModel.isPause = false;
        Time.timeScale = 1;
            SceneDataModel.lastScene = SceneManager.GetActiveScene().name;
            SceneDataModel.curscene = name;
            Debug.Log(SceneDataModel.lastScene + " " + SceneDataModel.curscene + gameObject.name);
            SoundManager.Instance.PlayAudioByName("click");
            if (isEnd)
                sceneName = name;
            else
               SceneManager.LoadScene(name);
        
        
        
    }

    public void Exit()
    {
        SoundManager.Instance.PlayAudioByName("click");

        Debug.Log("Game saved.");
        mySaveLoad.Save();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
