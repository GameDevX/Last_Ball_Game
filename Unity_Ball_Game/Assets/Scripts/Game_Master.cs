using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Master : MonoBehaviour {

    public string Next_Level;
    public int Level_To_Unlock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WinLevel()
    {
        if(PlayerPrefs.GetInt("levelReached")<Level_To_Unlock)
        {
            PlayerPrefs.SetInt("levelReached", Level_To_Unlock);
        }

        
    
        SceneManager.LoadScene(Next_Level);
    }
}
