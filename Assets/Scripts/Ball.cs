using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Config Params
    [SerializeField] Paddle paddle;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // State
    Vector3 paddleToBallDistance;
    bool hasStarted = false;


    // Cached item
    AudioSource ballAudioSource;
    Rigidbody2D myRB2D;

    // Use this for initialization
    void Start()
    {
        paddleToBallDistance = transform.position - paddle.transform.position;
        ballAudioSource = GetComponent<AudioSource>();
        myRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            stickBallToPaddle();
            if (Input.GetMouseButtonDown(0))
            {
                launchOnClick();
                hasStarted = true;
            }
        }
    }

    private void launchOnClick()
    {
        myRB2D.velocity = new Vector2(xPush, yPush);
    }

    private void stickBallToPaddle()
    {
        Vector3 paddlePos = paddle.transform.position;
        transform.position = paddlePos + paddleToBallDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(-randomFactor, randomFactor), UnityEngine.Random.Range(-randomFactor, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            ballAudioSource.PlayOneShot(clip);
            myRB2D.velocity += velocityTweak;
        }
    }
}
