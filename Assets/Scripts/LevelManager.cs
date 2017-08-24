using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            ScoreKeeper.ResetScore();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadNextLevel", 5f);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}