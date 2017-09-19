using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DefenderSpawner : MonoBehaviour
{
    private StarDisplay display;
    // Use this for initialization
    void Start()
    {
        display = FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (Button.selectedDefender)
        {
            int defenderCost = Button.selectedDefender.GetComponent<Defender>().GetStarCost();
            StarDisplay.Status result = display.UseStars(defenderCost);
            if (result == StarDisplay.Status.SUCCESS)
            {
                Vector2 rawPosition = CalculateMouseClickWorldPoint();
                Vector2 defenderPosition = SnapToGrid(rawPosition);
                Instantiate(Button.selectedDefender, defenderPosition, Quaternion.identity);
            }
            else if (result == StarDisplay.Status.FAILURE)
            {
                print("Not enough stars");
            }
        }
    }

    private Vector2 CalculateMouseClickWorldPoint()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY));
        return new Vector2(worldPoint.x, worldPoint.y);
    }

    private Vector2 SnapToGrid(Vector2 position)
    {
        return new Vector2(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }
}