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
    private Animator anim;
    private Renderer rend;
    private Vector3 colors;

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

        inputValue.x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * rot;
        inputValue.y = 0f;
        inputValue.z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * speed;

        anim.SetFloat("Forward", inputValue.z * 50f, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", inputValue.x, 0.1f, Time.deltaTime);

        transform.Translate(0, 0, inputValue.z);
        transform.Rotate(0, inputValue.x, 0);
        
    }

    
}
