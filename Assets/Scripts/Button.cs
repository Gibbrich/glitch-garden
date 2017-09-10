using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour
{
    private Button[] buttons;
    private static Button selectedButton;
    
    // Use this for initialization
    void Start()
    {
        buttons = FindObjectsOfType<Button>();
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

        selectedButton = this;
    }
}