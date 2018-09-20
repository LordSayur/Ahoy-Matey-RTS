using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Test : MonoBehaviour
{

    [SerializeField] float turn = 5f;
    [SerializeField] float speed = 5f;
    Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("hey");
    }

    void FixedUpdate()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        Debug.Log("H" + h + " V " + v);

        //transform.Translate(new Vector3(v, 0f, h));

        rb.AddTorque(0, h * turn, 0f);
        rb.AddForce(new Vector3(v, 0f, 0f) * speed);
    }
}
