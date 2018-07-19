using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage;
    public float lifeTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var hpScript = collision.gameObject.GetComponent<Alive>();
            var hp = hpScript.GetHP();
            collision.gameObject.GetComponent<Alive>().SetHP(hp - damage);
            Destroy(gameObject);
        }
    }
}
