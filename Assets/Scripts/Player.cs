using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;

    public float sideSpeed;
    public GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-sideSpeed, rb.velocity.y, rb.velocity.z);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(sideSpeed, rb.velocity.y, rb.velocity.z);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Vehicle" || coll.gameObject.tag == "Destroyer")
        {
            GameMan.inst.ExplosionAudio();
            Destroy(gameObject);
            GameObject exp = Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(exp, 3);
            GameMan.inst.RestartLevel();
        }
    }
}
