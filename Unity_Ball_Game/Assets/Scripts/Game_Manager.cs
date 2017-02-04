using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

    public GameObject[] Cark;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CarkDondur();	
	}
    

    void CarkDondur()
    {
        foreach (var cark in Cark)
        {
          
            cark.transform.Rotate(new Vector3(0,0,1.5f));
        }
    }

    
}
