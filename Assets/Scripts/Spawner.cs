using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject box;
    public float rate;
    public bool IsPlaying = false;

    void SpawnBox()
    { 
        Instantiate(box, transform.position, transform.rotation);
    }

    public void StartPlaying()
    {
        InvokeRepeating("SpawnBox", 2.0f,rate < 1 ? 1f : rate);
    }
}