using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plane : Alive {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    override protected void EventByDesiredHealthPoint(float hp) {
        if (hp <= 0)
            Destroy(gameObject);
    }
}
