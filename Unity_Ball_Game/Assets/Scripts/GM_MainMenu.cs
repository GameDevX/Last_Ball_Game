using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM_MainMenu : MonoBehaviour {


    [SerializeField]
    string pressButton = "pressButton";

    [SerializeField]
    string menuMusic = "menuMusic";

    public Button MusicOnButton;
    public Button MusicOfButton;
    public Button SoundOnButton;
    public Button SoundOfButton;


    int SoundCont, MusicCont;


    AudioManager audioManager;
    // Use this for initialization
    void Start()
    {
        
        SoundCont = PlayerPrefs.GetInt("SoundCont", 0);
        MusicCont = PlayerPrefs.GetInt("MusicCont", 0);

        if(SoundCont==0)
        {
            SoundOnButton.gameObject.SetActive(false);
            SoundOfButton.gameObject.SetActive(true);
        }
        else
        {
            SoundOnButton.gameObject.SetActive(true);
            SoundOfButton.gameObject.SetActive(false);
        }
        if (MusicCont == 0)
        {
            MusicOnButton.gameObject.SetActive(false);
            MusicOfButton.gameObject.SetActive(true);
        }
        else
        {
            MusicOnButton.gameObject.SetActive(true);
            MusicOfButton.gameObject.SetActive(false);
        }


        audioManager = AudioManager.instance;

        audioManager.PlayMusic(menuMusic);

    }

    public void Load_Level_Fade(string Level_Name)
    {
        audioManager.PlaySound(pressButton);
        float fadeTime = GameObject.Find("Fading_Scene").GetComponent<Fading_Scene>().BeginFade(-1);
        SceneManager.LoadScene(Level_Name);
    }

    public void PlayButton()
    {
        int currently_Level = PlayerPrefs.GetInt("levelReached"); ;
        Load_Level_Fade("Level_"+currently_Level);
    }

    public void ExitButton()
    {
        audioManager.PlaySound(pressButton);
        Application.Quit();
    }

    public void SoundButton()
    {
        audioManager.PlaySound(pressButton);
        SoundCont = PlayerPrefs.GetInt("SoundCont");
        if (SoundCont == 0)
        {
            SoundOnButton.gameObject.SetActive(true);
            SoundOfButton.gameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundCont", 1);
        }
        else
        {
            SoundOnButton.gameObject.SetActive(false);
            SoundOfButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("SoundCont", 0);
        }

    }
    public void MusicButton()
    {
        
        audioManager.PlaySound(pressButton);
        MusicCont = PlayerPrefs.GetInt("MusicCont");
        if (MusicCont == 0)
        {
            MusicOnButton.gameObject.SetActive(true);
            MusicOfButton.gameObject.SetActive(false);
            PlayerPrefs.SetInt("MusicCont", 1);
        }
        else
        {
            MusicOnButton.gameObject.SetActive(false);
            MusicOfButton.gameObject.SetActive(true);
            PlayerPrefs.SetInt("MusicCont", 0);
        }
        audioManager.PlayMusic(menuMusic);

    }
}
