using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public float height;
    public GameObject pipe;
    void Start()
    {
        GameObject newpipe = Instantiate(pipe);
        newpipe.transform.position = transform.position + new Vector3(0,UnityEngine.Random.Range(-height, height), 0);
    }
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newpipe = Instantiate(pipe);
            newpipe.transform.position = transform.position + new Vector3(0,UnityEngine.Random.Range(-height, height), 0);
            Destroy(newpipe,10);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
