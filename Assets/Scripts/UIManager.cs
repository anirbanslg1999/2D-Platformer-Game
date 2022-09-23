using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] List<Image> healthImg;
    [SerializeField] Sprite healthLostIcon;
    private int healthCountIndex = 0;

    public void DecrementHealthCout()
    {
        if(healthCountIndex < healthImg.Count - 1)
        {
            healthImg[healthCountIndex].sprite = healthLostIcon;
            healthCountIndex++;
        }
        else
        {
            PlayerDead();
        }
    }
    void PlayerDead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
