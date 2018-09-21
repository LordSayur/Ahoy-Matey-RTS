using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandling : MonoBehaviour {

    Animator anim;

    public float leftIKWeight = 1;
    public float rightIKWeight = 1;

    public Transform leftIKTarget;
    public Transform rightIKTarget;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftIKWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightIKWeight);

        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftIKWeight);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightIKWeight);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftIKTarget.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightIKTarget.position);

        anim.SetIKRotation(AvatarIKGoal.LeftHand, leftIKTarget.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, rightIKTarget.rotation);
        
    }
}
