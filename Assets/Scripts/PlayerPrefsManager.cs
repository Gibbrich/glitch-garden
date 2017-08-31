using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : BaseMonoBehaviour
{
    private const string TAG = "PlayerPrefsManager";
    
    private const string MASTER_VOLUME_KEY = "MASTER_VOLUME_KEY";
    private const string DIFFICULTY_KEY = "DIFFICULTY_KEY";
    private const string LEVEL_KEY = "level_unlocked_";

    public static float MasterVolume
    {
        get
        {
            return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.5f);
        }
        
        set
        {
            if (value >= 0 && value <= 1)
            {
                PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value);            
            }
            else
            {
                printError(TAG, "Master volume must be in range [0;1]");
            }
        }
    }

    public static float Difficulty
    {
        get
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY, 0);
        } 
        
        set
        {
            if (value >= 0 && value <= 1)
            {
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);                
            }
            else
            {
                printError(TAG, "Difficulty must be in range [0;1]");
            }
        }
    }

    public static void UnlockLevel(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level, 1);
        }
        else
        {
            printError(TAG, "Trying to unlock level not included in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings - 1)
        {
            return PlayerPrefs.GetInt(LEVEL_KEY + level, 0) == 1;
        }
        else
        {
            printError(TAG, "Trying to access level not included in build order");
            return false;
        }
    }
}