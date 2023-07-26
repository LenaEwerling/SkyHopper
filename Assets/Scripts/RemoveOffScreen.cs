using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOffScreen : MonoBehaviour
{
    private StepSpawner stepSpawnerScript;

    // Start is called before the first frame update
    void Start()
    {
        stepSpawnerScript = GameObject.Find("Spawner").GetComponent<StepSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.2f)
        {
            Destroy(gameObject);
            stepSpawnerScript.SpawnStep(6.2f);
        }
    }
}
