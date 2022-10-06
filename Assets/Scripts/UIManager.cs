using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get{ return instance; }}
    [Header("Sprites")]
    [SerializeField] List<Image> healthImg;
    [SerializeField] Sprite healthLostIcon;
    [Header("Panels")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject gameWonPanel;
    [Header("Gameobjects")]
    [SerializeField] PlayerController playerController; 
    private int healthCountIndex = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
            GameOverPanel();
        }
    }

    public void GameOverPanel()
    {
        inGamePanel.SetActive(false);
        gameEndPanel.SetActive(true);
        gameWonPanel.SetActive(false);
        playerController.enabled = false;
    }

    public void ReloadScene()
    {
        AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToMainMenu()
    {
        AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
        Application.Quit();
    }

    public void GameWinUI()
    {
        inGamePanel.SetActive(false);
        gameEndPanel.SetActive(false);
        gameWonPanel.SetActive(true);
        playerController.enabled = false;
    }
}
