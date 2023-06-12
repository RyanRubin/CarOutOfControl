using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnWhat;
    public GameObject roadLine;

    void Start()
    {
        InvokeRepeating("Spawn", 1, 0.25f);
    }

    void Update()
    {

    }

    void Spawn()
    {
        GameObject what = spawnWhat[Random.Range(0, spawnWhat.Length)];
        Instantiate(what, transform.position + new Vector3(Random.Range(-10f, 10f), 0, 0), what.transform.rotation);

        Instantiate(roadLine, new Vector3(transform.position.x, roadLine.transform.position.y, transform.position.z), roadLine.transform.rotation);
    }
}
