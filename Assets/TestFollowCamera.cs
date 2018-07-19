using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowCamera : MonoBehaviour {

    public GameObject targetToFollow;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - targetToFollow.transform.position;
    }
	
    //왜 여기서 LateUpdate 썼을까?
     void LateUpdate()
    {
        transform.position = targetToFollow.transform.position+ offset;
    }
}
