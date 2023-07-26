using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        PlayerPrefs.SetInt("GameOver", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.position.y < 0)
        {
            PlayerPrefs.SetInt("GameOver", 1);
        }
    }
}
