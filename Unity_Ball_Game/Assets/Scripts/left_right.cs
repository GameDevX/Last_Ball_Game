using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_right : MonoBehaviour {
	public Rigidbody eleman;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0.09f, 0, 0);

	}

    void OnCollisionEnter(Collision collision)
    {
       
        
            if (collision.gameObject.name == "alt_zemin")
            {
                Debug.Log("sol değdi");
                transform.position += new Vector3(3f, 0, 0);
            }

            if (collision.gameObject.name == "finish")
            {
				
                Debug.Log("sağ değdi");
                transform.position += new Vector3(-70f, 0, 0);
            }
        
        
    }

    
}
