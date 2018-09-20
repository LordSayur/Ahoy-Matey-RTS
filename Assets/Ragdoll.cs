using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour {

    BoxCollider[] boxes;
    CapsuleCollider[] capsules;

    // Use this for initialization
    void Start () {
        boxes = GetComponentsInChildren<BoxCollider>();
        capsules = GetComponentsInChildren<CapsuleCollider>();
        
        foreach (BoxCollider box in boxes)
        {
            box.enabled = false;
        }

        boxes[0].enabled = true;

        foreach (CapsuleCollider capsule in capsules)
        {
            capsule.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            GetComponentInParent<Animator>().enabled = false;
            GetComponentInParent<CapsuleCollider>().enabled = false;
            GetComponentInParent<Rigidbody>().useGravity = false;
            foreach (BoxCollider box in boxes)
            {
                box.enabled = true;
            }
            foreach (CapsuleCollider capsule in capsules)
            {
                capsule.enabled = true;
            }
        }
        
    }

}
