using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] List<Image> healthImg;
    [SerializeField] Sprite healthLostIcon;
    [Header("Panels")]
    [SerializeField] GameObject gameEndPanel;
    [SerializeField] GameObject inGamePanel;
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
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
