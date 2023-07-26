using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStepsDown : MonoBehaviour
{
    private float speed = 0.7f;
    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("StartMoving") == 1 && PlayerPrefs.GetInt("GameOver") == 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
