using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{   
    public GameObject waitingPanel;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gameCompletedPanel;

    private AssetBundle _myLoadedAssetBundle;
    private string[] _scenePaths;

    public Scene nextScene;

    private int _currentScore = 0;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        //_myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/scenes");
        //_scenePaths = _myLoadedAssetBundle.GetAllScenePaths();
    }
    public void GameStarted()
    {
        waitingPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelCompletedPanel.SetActive(false);
        scoreText.text = _currentScore.ToString();
    }
    public void GameEnded()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void GameCompleted()
    {
        gameCompletedPanel.SetActive(true);
    }
  
    

    public void LevelCompletedScene()
    {
        levelCompletedPanel.SetActive(true);
        StartCoroutine(LoadSceneWithDelay());
    }

    public IEnumerator LoadSceneWithDelay()
    {
        //int i;
        yield return new WaitForSeconds(2f);
        //for(i=1; i<=4;i++)
        //{
            //SceneManager.LoadScene(i);
        //}
        
        SceneManager.LoadScene(GameManager.Instance.levelManager.nextLevel);
        
        //SceneManager.LoadScene(nextLevelSceneLoad+1, LoadSceneMode.Single);
        //nextLevelSceneLoad += i;
        //i++;

        //SceneManager.LoadScene(_scenePaths[0], LoadSceneMode.Single);
        GameManager.Instance.StartGame();
    }

    public void LevelCompleted()
    {
        StartCoroutine(LevelComplete());
        levelCompletedPanel.SetActive(false);
    }
    public IEnumerator LevelComplete()
    {
        LevelCompleted();
        yield return new WaitForSeconds(2f);
    }
    

    public void FruitCollected(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
    
 
}
