using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject levelPanel;

    private void Start()
    {
        startPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void StartGame()
    {
        startPanel.SetActive(false);
        levelPanel.SetActive(true);
        AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
