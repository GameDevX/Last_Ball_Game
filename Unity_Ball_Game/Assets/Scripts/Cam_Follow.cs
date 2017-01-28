using UnityEngine;
using System.Collections;

public class Cam_Follow : MonoBehaviour {

    public static Cam_Follow Instance;

    public Transform Target;
    private float _amplitude = 0.1f;//Genlik miktarı
    
    private bool isShaking = false;//Sallanıyor mu ?
    private Vector3 initialPosition;//Başlangıç pozisyonu

    Vector3 offset = new Vector3(0, 0, -10);
	void Start () {
        Instance = this;
        
    }

    public void Shake(float amplitude, float duration)//Duration = süre
    {
        initialPosition = transform.localPosition;
        isShaking = true;
        _amplitude = amplitude;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    public void StopShaking()
    {
        Ball_Move.instance.GameOver();
        isShaking = false;
    }

    void Update()
    {
        if(isShaking)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * _amplitude;
        }
        
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if(!isShaking)
        {
            Vector3 desiredPosition = new Vector3(Target.transform.position.x, 0, 0) + offset;
            transform.position = desiredPosition;
        }
       
	
	}
}
