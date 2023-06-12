using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLine : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, 0, -10 * Time.deltaTime);

        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
