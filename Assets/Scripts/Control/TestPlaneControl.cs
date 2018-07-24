using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaneControl : MonoBehaviour {
    public List<Gun> guns = new List<Gun>();

    public float forwardSpeed = 10f;
    public float rotateSpeed = 10f;

    protected void PullTrigger()
    {
        if (guns.Count > 0)
        {
            foreach (Gun gun in guns)
            {
                gun.PullTrigger();
            }
        }
        else
            guns[0].PullTrigger();
    }

    protected void MoveForward()
    {
        transform.position = transform.position + transform.forward * forwardSpeed * Time.deltaTime;
    }
}
