using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class Shop_Manager : MonoBehaviour {

    string pressButton = "pressButton";
    string menuMusic = "menuMusic";

    public Button[] Buy_Buttons;
    public Button[] Use_Buttons;
    AudioManager audioManager;
    public IDbConnection dbconn;
    public int Coin;
    // Use this for initialization
    void Start () {
        Coin = PlayerPrefs.GetInt("Coin", 0);
        audioManager = AudioManager.instance;
        audioManager.PlayMusic(menuMusic);
        DatabaseOpen();
        DBConnect();
        dbconn.Close();
      

    }

    public void DatabaseOpen()
    {
        string path = "URI=file:" + Application.dataPath + "/Database/Shop1db.s3db";
        string conn = path;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
    }

    public void Buy_Ball(int Ball_Cost)
    {
        if(PlayerPrefs.GetInt("Coin") >= Ball_Cost)
        {
            Debug.Log("Satın alınma başarılı");
            //BuyingBallData(idSearch(Ball_Cost)); Çalışmıyoor yarın bakarız
        }
        else
        {
            Debug.Log("Yetersiz Bakiye");
        }
    }

    //void BuyingBallData(int id)
    //{
    //    IDbCommand dbcmd2 = dbconn.CreateCommand();

    //    string SqlQuery = string.Format("UPDATE Balls SET isBuy={0},isUse={1} WHERE Ball_id={2}",0, 1, id);

    //    dbcmd2.CommandText = SqlQuery;
    //    dbcmd2.ExecuteScalar(); 

    //}
    int idSearch(int Cost)
    {
        
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Ball_id,isBuy,isUse,Cost " + "FROM Balls";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int isBuy = reader.GetInt32(1);
            int isUse = reader.GetInt32(2);
            int Costd = reader.GetInt32(3);

            if (Cost == Costd)
            {
                return id;
            }
        }
        return -1;
        
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
    }

    void DBConnect()
    {
       
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Ball_id,isBuy,isUse " + "FROM Balls";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int isBuy = reader.GetInt32(1);
            int isUse = reader.GetInt32(2);

            if(isBuy==1)
            {
                Buy_Buttons[id - 1].interactable = false;

            }
            if (isUse == 0)
            {
                Use_Buttons[id - 1].interactable = false;

            }
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Load_Level_Fade(string Level_Name)
    {
        audioManager.PlaySound(pressButton);
        float fadeTime = GameObject.Find("Fading_Scene").GetComponent<Fading_Scene>().BeginFade(-1);
        SceneManager.LoadScene(Level_Name);
    }
}
