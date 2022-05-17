using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "paddle")
        {
            Vector3 vec = Vector3.zero;
            if (Mathf.Abs(rb.velocity.z) < 5f)
            {
                vec.z = rb.velocity.z > 0 ? 5f : -5f;
            }

            if (Mathf.Abs(rb.velocity.x) < 5f)
            {
                vec.z = rb.velocity.x > 0 ? 5f : -5f;
            }
            rb.velocity += vec;
        }

    }
}
