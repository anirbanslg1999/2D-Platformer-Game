using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public string[] LevelName;
    //[SerializeField] private List<Image> levelStatusIcon;
   // [SerializeField] private List<Sprite> levelStatusSprite;

    private static LevelManager instance;
/*    [SerializeField] GameObject levelPanel;
    [SerializeField] GameObject startPanel;*/
    public static LevelManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(LevelName[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(LevelName[0], LevelStatus.Unlocked);  
        }
        //levelStatusIcon[0].sprite = levelStatusSprite[1];
    }
    private void Update()
    {
/*        for (int i = 0; i < LevelName.Length; i++)
        {
            SetLevelStatus(LevelName[i], LevelStatus.Locked);
            LevelStatus status = GetLevelStatus(LevelName[i]);
            Debug.Log("Level Name : " + LevelName[i] + " Level Status " + status);
        }*/
    }

    

    public void MoveToNextScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SetLevelStatus(currentScene.name,LevelStatus.Completed);
        int currentSceneIndex = Array.FindIndex(LevelName, Level => Level == currentScene.name);
/*        Debug.Log("Current Index : " + currentSceneIndex);
        Debug.Log("Current Scene Index : " + currentScene.buildIndex);*/
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex < LevelName.Length)
        {
        SetLevelStatus(LevelName[nextSceneIndex], LevelStatus.Unlocked);
        }
        
/*        startPanel.SetActive(false);
        levelPanel.SetActive(true);*/
    }
    public void ChangeIconAndLoad(int currentIndex, int nextIndex)
    {
/*      SceneManager.LoadScene(0);
        LevelStatus iconIndexToplay =(LevelStatus) GetLevelStatus(LevelName[currentIndex]);
        levelStatusIcon[currentIndex].sprite = levelStatusSprite[(int)iconIndexToplay];
        iconIndexToplay = (LevelStatus)GetLevelStatus(LevelName[nextIndex]);
        levelStatusIcon[nextIndex].sprite = levelStatusSprite[(int)iconIndexToplay];*/
    }

    public LevelStatus GetLevelStatus(string Level)
    {
        LevelStatus levelStats = (LevelStatus)PlayerPrefs.GetInt(Level,0);
        return levelStats;
    }
    public void SetLevelStatus(string Level, LevelStatus levelstatus)
    {
        PlayerPrefs.SetInt(Level, (int)levelstatus);
        //Debug.Log("Level name :" + Level + " Level Status :" + levelstatus);
    }
}
