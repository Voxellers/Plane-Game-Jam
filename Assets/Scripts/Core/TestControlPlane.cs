using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControlPlane : MonoBehaviour {

    public float forwardSpeed = 10f;
    public float rotateSpeed = 10f;
    public Gun playerGun;
    float axisValue;

    // Update is called once per frame
    void Update () {
        if(Input.GetButton("Fire1"))
        {
            playerGun.PullTrigger();
        }
        transform.position = transform.position + transform.forward *forwardSpeed* Time.deltaTime;

        axisValue = Input.GetAxis("Vertical");
        transform.Rotate(axisValue * rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}
