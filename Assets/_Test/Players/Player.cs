using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class Player : NetworkBehaviour {

    private Vector3 inputValue;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float rot = 15f;
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawn;
    private Animator anim;
    private Renderer rend;
    private Vector3 colors;
    [SerializeField] float power = 5f;

    public override void OnStartLocalPlayer()
    {
        GetComponentInChildren<Camera>().enabled = true;
        rend = GetComponentInChildren<Renderer>();
        colors = new Vector3(Random.value, Random.value, Random.value);
        rend.materials[1].color = new Color(Random.value, Random.value, Random.value, 1f);
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        GetComponentInChildren<Renderer>().materials[1].color = new Color(Random.value, Random.value, Random.value, 1f);
    }
	
	// Update is called once per frame
	void Update () 
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            CmdFireLeft();
        }

        inputValue.x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * rot;
        inputValue.y = 0f;
        inputValue.z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * speed;

        anim.SetFloat("Forward", inputValue.z * 50f, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", inputValue.x, 0.1f, Time.deltaTime);

        transform.Translate(0, 0, inputValue.z);
        transform.Rotate(0, inputValue.x, 0);
        
    }

    [Command]
    private void CmdFireLeft()
    {
        var bullet = (GameObject)Instantiate(
            bulletPref,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * power;

        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 5.0f);
    }


}
