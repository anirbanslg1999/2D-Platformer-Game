using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReloadScene : MonoBehaviour
{
    [SerializeField] float reloadSceneTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Invoke("LoadCurrentGameScene", reloadSceneTime);
        }
    }
    public void LoadCurrentGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
