using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonoBehaviour : MonoBehaviour
{
    public static void print(string tag, object message)
    {
        MonoBehaviour.print(string.Format("[{0}] {1}", tag, message));
    }

    public static void printError(string tag, object message)
    {
        Debug.LogError(string.Format("[{0}] {1}", tag, message));
    }
}