using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM_LevelSelect : MonoBehaviour {
    
    public Button[] Buttons;

    [SerializeField]
    string pressButton = "pressButton";

    [SerializeField]
    string menuMusic = "menuMusic";

    AudioManager audioManager;

    void Start () {

        audioManager = AudioManager.instance;
        audioManager.PlayMusic(menuMusic);

        int levelReached = PlayerPrefs.GetInt("levelReached", 1); // Ulaştığı seviyeyi değişkene atıyoruz

        for (int i = 0; i < Buttons.Length; i++)
        {
            if(i + 1 > levelReached) // ulaşamadığı levellları pasif hale getiriyoruz
            {
                Buttons[i].interactable = false;
            }
        }
		
	}	
    public void Load_Level_Fade(string Level_Name)
    {
        audioManager.PlaySound(pressButton);
        float fadeTime = GameObject.Find("Fading_Scene").GetComponent<Fading_Scene>().BeginFade(-1);
         SceneManager.LoadScene(Level_Name);
    }

    //void Play_Sound(AudioClip Clip)
    //{
    //   AudioSource Audio_Source = gameObject.GetComponent<AudioSource>();
    //    Audio_Source.PlayOneShot(Clip);
    //}
}
