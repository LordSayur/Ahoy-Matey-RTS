using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
using Random = UnityEngine.Random;

public class ShipController : NetworkBehaviour {

    [SerializeField]float turn = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject cannonBall;
    [SerializeField] Transform[] cannonSpawns;
    [SerializeField] float power = 5f;
    Rigidbody rb;
    Renderer rend;
    Vector3 colors;

    

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rend.material.color = new Color(Random.value, Random.value, Random.value, 1f);
    }
	
	void FixedUpdate ()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            //rb.isKinematic = true;
            CmdFireLeft();
            //rb.isKinematic = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            //rb.isKinematic = true;
            CmdFireRight();
            //rb.isKinematic = false;
        }

        rb.AddTorque(0, h * turn * Time.deltaTime, 0f);
        rb.AddForce(transform.right * v * speed * Time.deltaTime);
	}

    [Command]
    private void CmdFireLeft()
    {
        for (int i = 0; i < 5; i++)
        {
            var bullet = (GameObject)Instantiate(
            cannonBall,
            cannonSpawns[i].position,
            cannonSpawns[i].rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * power;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 5.0f);
        }
    }

    [Command]
    private void CmdFireRight()
    {
        for (int i = 5; i < 10; i++)
        {
            var bullet = (GameObject)Instantiate(
            cannonBall,
            cannonSpawns[i].position,
            cannonSpawns[i].rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * power;

            // Spawn the bullet on the Clients
            NetworkServer.Spawn(bullet);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 5.0f);
        }
    }

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<Camera>().enabled = true;
        rend = GameObject.Find("Sails").GetComponent<Renderer>();
        colors = new Vector3(Random.value, Random.value, Random.value);
        rend.material.color = new Color(Random.value, Random.value, Random.value, 1f);
    }
}
