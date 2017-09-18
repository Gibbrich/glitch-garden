using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour
{
    public GameObject Prefab;
    private Button[] buttons;
    public static GameObject selectedDefender;
    private Text costText;
    
    // Use this for initialization
    void Start()
    {
        buttons = FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning(name + " has no cost text");
        }
        costText.text = Prefab.GetComponent<Defender>().StarCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = button.gameObject != gameObject ? Color.black : Color.white;
        }

        selectedDefender = Prefab;
    }
}