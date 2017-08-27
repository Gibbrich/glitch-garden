using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonoBehaviour : MonoBehaviour
{
    public new static void print(object message)
    {
        MonoBehaviour.print(string.Format("[{0}] {1}", typeof(BaseMonoBehaviour), message));
    }

    public static void printError(object message)
    {
        Debug.LogError(string.Format("[{0}] {1}", typeof(BaseMonoBehaviour), message));
    }
}