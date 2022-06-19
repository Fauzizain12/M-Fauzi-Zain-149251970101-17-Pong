using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<BallController>().leftLastCol())
            {
                leftPaddle.GetComponent<PaddleController>().ActivatePULongPaddle(magnitude);
                manager.RemovePowerUp(gameObject);
            }
            else
            {
                rightPaddle.GetComponent<PaddleController>().ActivatePULongPaddle(magnitude);
                manager.RemovePowerUp(gameObject);
            }

        }
    }
}
