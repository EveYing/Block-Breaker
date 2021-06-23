using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    float minX = 1f;
    float maxX = 20.3f;
    float moveSpeed = 20f;

    // cached refs
    GameSession gs;
    Ball ball;

    private void Start()
    {
        gs = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x != transform.position.x)
        {
            float xPosition = getXPos(mousePosition);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
    }

    private float getXPos(Vector3 mousePosition)
    {
         
        if (gs.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Mathf.Clamp(mousePosition.x,
                Mathf.Max(minX, transform.position.x - moveSpeed * Time.deltaTime),
                Mathf.Min(maxX, transform.position.x + moveSpeed * Time.deltaTime));
        }
    }
}
