using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("00 Splash"))
        {
            Invoke("LoadNextLevel", 5f);
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