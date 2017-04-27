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

    public Text Coin_txt;

    public Button[] Buy_Buttons;
    public Button[] Use_Buttons;
    AudioManager audioManager;
    public IDbConnection dbconn;
    public int Coin,Ball_ID;
    // Use this for initialization
    void Start () {
        
        string path = "URI=file:" + Application.dataPath + "/Database/Shop1db.s3db";
        dbconn = (IDbConnection)new SqliteConnection(path);

        Coin = PlayerPrefs.GetInt("Coin", 0);
        Ball_ID = PlayerPrefs.GetInt("Current_Ball_id", 1);
        PlayerPrefs.SetInt("Coin", 100);
        audioManager = AudioManager.instance;
        audioManager.PlayMusic(menuMusic);
        Shop_Ref();      
        Coin_Text();
        Debug.Log(PlayerPrefs.GetInt("Coin").ToString());

    }

    void Coin_Text()
    {
        Coin_txt.text = PlayerPrefs.GetInt("Coin").ToString();
    }

    public void Use_Ball(int Ball_id)
    {   
        string path = "URI=file:" + Application.dataPath + "/Database/Shop1db.s3db";
        dbconn = (IDbConnection)new SqliteConnection(path);
        dbconn.Open();
        //----------------------------------------------
        IDbCommand dbcmd3 = dbconn.CreateCommand();

        string SqlQuery1 = string.Format("UPDATE Balls SET isUse={0} WHERE Ball_id={1}", 1, PlayerPrefs.GetInt("Current_Ball_id"));

        dbcmd3.CommandText = SqlQuery1;
        dbcmd3.ExecuteScalar();

        dbconn.Close();
        dbcmd3.Dispose();
        dbcmd3 = null;
        //-----------------------------

        dbconn.Open();
        PlayerPrefs.SetInt("Current_Ball_id", Ball_id);

        IDbCommand dbcmd2 = dbconn.CreateCommand();

            string SqlQuery = string.Format("UPDATE Balls SET isUse={0} WHERE Ball_id={1}",0, Ball_id);

            dbcmd2.CommandText = SqlQuery;
            dbcmd2.ExecuteScalar();

            dbconn.Close();
            dbcmd2.Dispose();
            dbcmd2 = null;

        Shop_Ref();

    }

    public void Buy_Ball(int Ball_Cost)
    {
        if(PlayerPrefs.GetInt("Coin") >= Ball_Cost)
        {
            Debug.Log("Satın alınma başarılı");
            int id = idSearch(Ball_Cost);
            Debug.Log(id);
            BuyingBallData(id);
            Shop_Ref();
            Coin_Text();
            
        }
        else
        {
            Debug.Log("Yetersiz Bakiye");
        }
    }

    void BuyingBallData(int id)
    {
        string path = "URI=file:" + Application.dataPath + "/Database/Shop1db.s3db";
        dbconn = (IDbConnection)new SqliteConnection(path);
        dbconn.Open();
        try 
        {
            IDbCommand dbcmd2 = dbconn.CreateCommand();

            string SqlQuery = string.Format("UPDATE Balls SET isBuy={0},isUse={1} WHERE Ball_id={2}", 1, 1, id);

            dbcmd2.CommandText = SqlQuery;
            dbcmd2.ExecuteScalar();

            dbconn.Close();
            dbcmd2.Dispose();
            dbcmd2 = null; 
        }
        catch (Exception)
        {

            throw;
        }
       
        

    }
    int idSearch(int Cost)
    {
        string path = "URI=file:" + Application.dataPath + "/Database/Shop1db.s3db";
        dbconn = (IDbConnection)new SqliteConnection(path);
        dbconn.Open();   
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Ball_id,Cost " + "FROM Balls";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int Costd = reader.GetInt32(1);

            if (Cost == Costd)
            {

                dbconn.Close();
                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;

                return id;

               
            }
        }

        dbconn.Close();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;

        return -1;

      

    }

    void Shop_Ref()
    {
        dbconn.Open();  
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
            else
            {
                Buy_Buttons[id - 1].interactable = true;
            }

            if(isBuy==1 && isUse==1)
            {
                Use_Buttons[id - 1].interactable = true;
            }

            if(isUse==0)
            {
                Use_Buttons[id - 1].interactable = false;
            }




        
        }
        dbconn.Close();
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
    }
    public void Load_Level_Fade(string Level_Name)
    {
        audioManager.PlaySound(pressButton);
        float fadeTime = GameObject.Find("Fading_Scene").GetComponent<Fading_Scene>().BeginFade(-1);
        SceneManager.LoadScene(Level_Name);
    }
}
