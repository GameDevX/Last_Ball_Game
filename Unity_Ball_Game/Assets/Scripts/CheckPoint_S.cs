using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint_S : MonoBehaviour {

    public Transform CheckPoint_Tra;
    Transform[] CheckPoint_T_Array;
    int[][] CheckPoint_i_array;            

    void Start () {

    
        Scene scene = SceneManager.GetActiveScene();
        CheckPoint_T_Array = CheckPoint_Tra.GetComponentsInChildren<Transform>();
        if (PlayerPrefs.GetInt("ischeck") == 0)
        {
            int id = 0;
            foreach (Transform Child in CheckPoint_T_Array)
            {
                if(id == PlayerPrefs.GetInt("id"))
                {
                    
                    gameObject.transform.position = Child.transform.position;
                }
                id++;
            }
        }
        else
        {
            PlayerPrefs.SetInt("İscheck", 0);
        }

    }
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("İscheck", 1);

        int id = 0;
        foreach (Transform Child in CheckPoint_T_Array)
        {
            Scene scene = SceneManager.GetActiveScene();
           
           
            if (Child.transform.position == other.transform.position)
            {
                PlayerPrefs.SetInt("Levelid", scene.buildIndex);
                PlayerPrefs.SetInt("id", id);
            }
            id++;
        }
    }
}
