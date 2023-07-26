using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSpawner : MonoBehaviour
{
    private int position = 0;
    

    public GameObject stepPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnStep(2);
        SpawnStep(3);
        SpawnStep(4);
        SpawnStep(5);
        SpawnStep(6);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnStep(float y)
    {
        Vector3 spawnPos = new Vector3(0, y, 0);
        if (position == 0)
        {
            spawnPos = new Vector3(-1.5f, y, 0);
            position = 1;
        }
        else if (position == 3)
        {
            spawnPos = new Vector3(0, y, 0);
            position = 2;
        }
        else if (position == 1)
        {
            if (Random.Range(0, 2) == 0)
            {
                spawnPos = new Vector3(-3, y, 0);
                position = 0;
            }
            else 
            {
                spawnPos = new Vector3(0, y, 0);
                position = 2;
            }
        }
        else if (position == 2)
        {
            if (Random.Range(0, 2) == 0)
            {
                spawnPos = new Vector3(-1.5f, y, 0);
                position = 1;
            }
            else 
            {
                spawnPos = new Vector3(1.5f, y, 0);
                position = 3;
            }
        }
        Instantiate(stepPrefab, spawnPos, stepPrefab.transform.rotation);
    }
}
