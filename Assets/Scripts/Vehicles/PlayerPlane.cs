using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : Plane {

    public void Update()
    {
        if (transform.position.y >= 550f)
        {
            print("Danger Danger");
        }
        if(transform.position.y >= 650)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
