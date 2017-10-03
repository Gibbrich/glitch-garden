using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public const string TAG = "LevelManager";
    
    public float AutoLoadNextScene = 4f;
    
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        MusicManager.Instance.PlaySceneMusic(scene.buildIndex, scene.buildIndex != 0);
        
        if (SceneManager.GetActiveScene().name.Equals(Levels.SPLASH))
        {
            FindObjectOfType<FaderManager>().FadeOut(AutoLoadNextScene);
        }
        else if (SceneManager.GetActiveScene().name.Equals(Levels.LEVEL_01))
        {
            Utils.print(TAG, PlayerPrefsManager.Difficulty);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevel(float time)
    {
        Invoke("LoadNextLevel", time);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    public static class Levels
    {
        public const string SPLASH = "00 Splash";
        public const string START = "01a Start";
        public const string OPTIONS = "01b Options";
        public const string LEVEL_01 = "02 Level 01";
        public const string LEVEL_02 = "02 Level 02";
        public const string LEVEL_03 = "02 Level 03";
        public const string WIN = "03a Win";
        public const string LOSE = "03b Lose";
    }
}