using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {


	public GameObject engel1;
	public GameObject engel2;
	public GameObject engel3;
	public GameObject engel4;
	public GameObject alt_zemin;
	public float right_speed = 35;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		engel1.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * right_speed));
		engel2.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * right_speed));
		engel3.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * right_speed));
	}


}
