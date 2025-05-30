using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField]private float maxTime = 1;
    [SerializeField]private float timer = 0;
    [SerializeField]private float height;
    [SerializeField]private GameObject pipe;
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
            newpipe.transform.position = transform.position + new Vector3(0, UnityEngine.Random.Range(-height, height), 0);
            Destroy(newpipe, 10);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
    
}
