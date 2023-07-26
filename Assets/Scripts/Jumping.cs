using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 5.0f;
    private bool isOnGround = true;

    private Rigidbody playerRb;
    private StepSpawner spawnerScript;
    private MoveStepsDown movingScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        GameObject spawnerObject = GameObject.FindWithTag("Spawner");
        spawnerScript = spawnerObject.GetComponent<StepSpawner>();
        PlayerPrefs.SetInt("StartMoving", 0);
    }

    // Update is called once per frame
    void Update()
    {
        JumpLeft();
        JumpRight();
    }

    void JumpLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerRb.AddForce(Vector3.left * jumpForce * 0.4f, ForceMode.Impulse);
            playerRb.constraints = RigidbodyConstraints.FreezeRotation;
            isOnGround = false;
        }
    }

    void JumpRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerRb.AddForce(Vector3.right * jumpForce * 0.4f, ForceMode.Impulse);
            playerRb.constraints = RigidbodyConstraints.FreezeRotation;
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Step") && !isOnGround)
        {
            isOnGround = true;
            PlayerPrefs.SetInt("StartMoving", 1);
            
            Rigidbody stepRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (stepRigidbody != null)
            {
                // Adjust player's velocity relative to the platform's movement
                playerRb.velocity -= stepRigidbody.velocity;
            }
        }
    }
}
