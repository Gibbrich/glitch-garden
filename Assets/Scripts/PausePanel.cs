using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ResumeGame()
    {
        LevelManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }

    public void RestartLevel()
    {
        LevelManager.Instance.LoadLevel(SceneManager.GetActiveScene().name);
        LevelManager.Instance.ResumeGame();
    }

    public void ExitToMainMenu()
    {
        LevelManager.Instance.LoadLevel(LevelManager.Levels.START);
        LevelManager.Instance.ResumeGame();
    }
}