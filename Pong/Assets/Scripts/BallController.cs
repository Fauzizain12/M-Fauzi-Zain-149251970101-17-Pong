using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;
    private bool isLeftLastCol;
    private Vector2 initSpeed;

    // Start is called before the first frame update

    public bool leftLastCol()
    {
        return isLeftLastCol;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle Kiri")
        {
            isLeftLastCol = true;
        }
        else if (collision.gameObject.name == "Paddle Kanan")
        {
            isLeftLastCol = false;
        }

    }

   

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
        initSpeed = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
        StartCoroutine(SpeedUpTimer(magnitude));
    }

    public void DeactivatePUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }

    private IEnumerator SpeedUpTimer(float magnitude)
    {
        yield return new WaitForSeconds(5f);
        DeactivatePUSpeedUp(magnitude);
    }
}
