using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerPrefsManager
{
    private const string TAG = "PlayerPrefsManager";
    
    private const string MASTER_VOLUME_KEY = "MASTER_VOLUME_KEY";
    private const string DIFFICULTY_KEY = "DIFFICULTY_KEY";
    private const string LEVEL_KEY = "level_unlocked_";

    private const float MIN_DIFFICULTY = 1;
    private const float MAX_DIFFICULTY = 3;

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
                Utils.printError(TAG, "Master volume must be in range [0;1]");
            }
        }
    }

    public static float Difficulty
    {
        get
        {
            return PlayerPrefs.GetFloat(DIFFICULTY_KEY, MIN_DIFFICULTY);
        } 
        
        set
        {
            if (value >= MIN_DIFFICULTY && value <= MAX_DIFFICULTY)
            {
                PlayerPrefs.SetFloat(DIFFICULTY_KEY, value);                
            }
            else
            {
                Utils.printError(TAG, string.Format("Master volume must be in range [{0};{1}]", MIN_DIFFICULTY, MAX_DIFFICULTY));
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
            Utils.printError(TAG, "Trying to unlock level not included in build order");
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
            Utils.printError(TAG, "Trying to access level not included in build order");
            return false;
        }
    }

    public static void SetDefaults()
    {
        PlayerPrefs.DeleteKey(MASTER_VOLUME_KEY);
        PlayerPrefs.DeleteKey(DIFFICULTY_KEY);
    }
}