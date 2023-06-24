using System;
using UnityEngine;
public class GameUI : MonoBehaviour
{
    public GameObject playerselect;
    public GameObject menu;
    public bool click;

    private void Start()
    {
        click = false;
    }

    public void SelectBall()
    {
        click = true;
        playerselect.SetActive(true);
    }

    private void Update()
    {
        if (GlobalValues.missionStarted==true)
        {
            menu.SetActive(false);
        }
    }
    public void pause()
    {
        Time.timeScale = 0f;
    }
}
