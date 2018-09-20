using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Animator>().enabled = false;
        GetComponentInParent<CapsuleCollider>().enabled = false;

    }
}
