using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down_up : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0, -0.09f, 0);
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "alt_zemin_alt")
		{
			Debug.Log ("degdi");
			transform.position += new Vector3(0, 7.85f, 0);
		}
	}
}
