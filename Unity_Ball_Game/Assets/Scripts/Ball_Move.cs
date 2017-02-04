using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball_Move : MonoBehaviour {

   
    public static Ball_Move instance;
    bool isContact;
    public AudioClip Ball_bounce,Ball_Exp;
    public AudioSource Audio_Source;
    Rigidbody Ball_rb;



    // Use this for initialization
    void Start () {

        Ball_rb = gameObject.GetComponent<Rigidbody>();
        instance = this;
     
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        Ball_Movement(10);
        Ball_Jump(500);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            PlaySound(Ball_bounce);
            isContact = true;   
        }
        if(collision.gameObject.tag == "Block")
        {
            PlaySound(Ball_Exp);
            Cam_Follow.Instance.Shake(0.1f, 0.5f);
            
        }
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Bitirdin");
        }

    }

    void Ball_Jump(float Jump_Speed)
    {
        if (isContact)
        {
            Ball_rb.AddForce(new Vector3(0, Jump_Speed));
            isContact = false;
        }
    }
    
    void Ball_Movement(float speed)
    {
       
        float Move_Horizontal;
        Move_Horizontal = Input.GetAxis("Horizontal");
        Ball_rb.AddForce(new Vector3(Move_Horizontal * speed, 0, 0));
    }

    public void GameOver()
    {
       
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    public void PlaySound(AudioClip Sound_Clip)
    {
        Audio_Source.clip = Sound_Clip;
        Audio_Source.Play();
    }

}
