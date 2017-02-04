using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading_Scene : MonoBehaviour {

    

    public Texture2D FadeOutTexture; //Siyah bi resim yada yükleme ekranı geçiş sırasında gözükecek
    public float FadeSpeed = 0.1f;//Geçiş hızı süresi
    private int drawDept = -1000;
    private float alpha = 1.0f; //alpha değeri 0 ile 1 arasında olucak
    private int fadeDir = -1; // Soldurmanınn yani geçisin yönü

    void Update()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnGUI()
    {
        alpha += fadeDir * FadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b,alpha);
        GUI.depth = drawDept;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture);
       
    }

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (FadeSpeed);
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }

}
