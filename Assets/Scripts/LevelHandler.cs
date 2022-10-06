using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class LevelHandler : MonoBehaviour
{
    [SerializeField] string levelName;
    [SerializeField] private List<Sprite> levelStatusSprite;
    private Button button;
    [SerializeField] private Image image;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadRequiredLevel);
        
        //DontDestroyOnLoad(gameObject);
        LevelStatus checkStatus = LevelManager.Instance.GetLevelStatus(levelName);
        image.sprite = levelStatusSprite[(int)checkStatus];

    }

    private void LoadRequiredLevel()
    {
        //SceneManager.LoadScene(levelName);
        LevelStatus checkStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (checkStatus)
        {
            case LevelStatus.Locked:
                // Do Nothing;
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
                AudioManager.Instance.PlayBackGroundSound(SoundTypes.GameBG);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                AudioManager.Instance.PlayEffectSound(SoundTypes.ButtonPressed);
                AudioManager.Instance.PlayBackGroundSound(SoundTypes.GameBG);
                break;  
            
        }
    }

}

