using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
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
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            FindObjectOfType<FaderManager>().FadeOut(AutoLoadNextScene);
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
}