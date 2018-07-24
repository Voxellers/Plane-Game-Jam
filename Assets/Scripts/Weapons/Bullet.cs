﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage;
    public float lifeTime;
    public string targetTag;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            var hpScript = collision.gameObject.GetComponent<Alive>();
            var hp = hpScript.GetHP();
            collision.gameObject.GetComponent<Alive>().SetHP(hp - damage);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall")) Destroy(gameObject);
    }
}
