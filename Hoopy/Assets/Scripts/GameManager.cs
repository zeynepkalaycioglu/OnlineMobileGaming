using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public UIManager uiManager;
    public FruitManager fruitManager;
    public PlayerController playerController;
    public ObstacleManager obstacleManager;
    public LevelManager levelManager;
    
    
    public bool isGameStarted = false;
    public bool isLevelCompleted = false;
    public int score = 0;
    public int finalScore = 25;
    
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.Instance.PlayBgMusic(SoundManager.BgMusicTypes.MainBgMusic);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!isGameStarted)
            {
                StartGame();
            }
        }
    }
    public void StartGame()
    {
        levelManager = FindObjectOfType<LevelManager>();
        finalScore = levelManager.levelEndingScore;
        score = 0;
        isGameStarted = true;
        isLevelCompleted = false;
        playerController.StartGame();
        uiManager.GameStarted();
        obstacleManager.StartGame();
        IsLevelCompleted();
    }

    public void IsLevelCompleted()
    {
        if (score == finalScore)
        {
            uiManager.LevelCompletedScene();
            isLevelCompleted = true;
            AnalyticsResult analyticsResult = UnityEngine.Analytics.Analytics.
                CustomEvent
                ("Levelwin", new Dictionary<string, object>
                {
                    {"Level",SceneManager.GetActiveScene().buildIndex}, 
                    {"Position", playerController.GetPlayerPosition()},
                    {"LevelPlayTime", Time.timeSinceLevelLoad}
                });
            Debug.Log(analyticsResult);
        }
    }
  
    public void GameOver()
    {
        isGameStarted = false;
        playerController.GameEnded();
        uiManager.GameEnded();
        fruitManager.ResetFruits();
        StartCoroutine(GameRestart());
    }
    
    public IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level1");
    }
    
    public void GameCompleted(GameObject frog)
    {
        isGameStarted = false;
        uiManager.GameCompleted();
    }
    
    public void FruitCollected(GameObject fruit)
    {
        score++;
        IsLevelCompleted();
        uiManager.FruitCollected(score);
        fruitManager.FruitCollected(fruit);
    }

    public void CrashedObstacle(GameObject obstacle)
    {
        GameOver();
        AnalyticsResult analyticsResult = UnityEngine.Analytics.Analytics.
            CustomEvent
            ("Levelfailed", new Dictionary<string, object>
                {
                    {"Level",SceneManager.GetActiveScene().buildIndex}, 
                    {"Position", playerController.GetPlayerPosition()},
                    {"LevelPlayTime", Time.timeSinceLevelLoad}
                });
        Debug.Log(analyticsResult);
        
    }
}
