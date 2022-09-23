using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] List<Image> healthImg;
    [SerializeField] Sprite healthLostIcon;
    [Header("Panels")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] GameObject inGamePanel;
    [Header("Gameobjects")]
    [SerializeField] PlayerController playerController; 
    private int healthCountIndex = 0;

    private void Start()
    {
        inGamePanel.SetActive(true);
        gameEndPanel.SetActive(false);
    }

    public void DecrementHealthCout()
    {
        if (healthCountIndex < healthImg.Count - 1)
        {
            healthImg[healthCountIndex].sprite = healthLostIcon;
            healthCountIndex++;
        }
        else
        {
            inGamePanel.SetActive(false);
            gameEndPanel.SetActive(true);
            playerController.enabled = false;
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameWinUI()
    {
        //Implement game win function
    }
}
