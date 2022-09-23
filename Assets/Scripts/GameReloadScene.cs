using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReloadScene : MonoBehaviour
{
    [SerializeField] float reloadNextSceneTime;
    [SerializeField] UIManager uiManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Invoke("EnterPortal", reloadNextSceneTime);
        }
    }
    public void EnterPortal()
    {
        int totalScene = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Total Scene :" + totalScene + " current Scene : " + currentScene);
        if(currentScene < totalScene - 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Won the Game");
            uiManager.GameWinUI();
        }
    }
}
