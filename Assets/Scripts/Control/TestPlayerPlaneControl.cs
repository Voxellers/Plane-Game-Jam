using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerPlaneControl : TestPlaneControl
{
    float axisValue;

    // Update is called once per frame
    void Update () {
        if(Input.GetButton("Fire1"))
        {
            PullTrigger();
        }

        MoveForward();

        axisValue = Input.GetAxis("Vertical");
        transform.Rotate(axisValue * rotateSpeed * Time.deltaTime, 0, 0, Space.Self);
    }
}
