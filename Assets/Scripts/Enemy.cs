using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody rb;

    public float fwdSpeed;
    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -fwdSpeed);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Vehicle" || coll.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
            GameObject exp = Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(exp, 3);
        }
    }
}
