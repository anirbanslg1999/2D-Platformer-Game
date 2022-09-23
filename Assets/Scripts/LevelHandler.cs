using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class LevelHandler : MonoBehaviour
{
    [SerializeField] string levelName;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadRequiredLevel);
    }

    private void LoadRequiredLevel()
    {
        SceneManager.LoadScene(levelName);
    }

}
