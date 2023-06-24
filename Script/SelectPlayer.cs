using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    public GameObject playerselect;
    public void player0()
    {
        GlobalValues.playerNo = 0;
    }
    public void player1()
    {
        GlobalValues.playerNo = 1;
    }
    public void player2()
    {
        GlobalValues.playerNo = 2;
    }
    public void player3()
    {
        GlobalValues.playerNo = 3;
    }

    public void load()
    {
        playerselect.SetActive(false);       
        SceneManager.LoadScene( 1 , LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
