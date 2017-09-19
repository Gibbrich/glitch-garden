using UnityEngine;

public static class Utils
{
    public static void print(string tag, object message)
    {
        Debug.Log(string.Format("[{0}] {1}", tag, message));
    }

    public static void printError(string tag, object message)
    {
        Debug.LogError(string.Format("[{0}] {1}", tag, message));
    }

    public static void FindOrCreateParent(GameObject obj, string parentName)
    {
        GameObject parent = GameObject.Find(parentName);
        if (!parent)
        {
            parent = new GameObject(parentName);
        }
        obj.transform.parent = parent.transform;
    }
}