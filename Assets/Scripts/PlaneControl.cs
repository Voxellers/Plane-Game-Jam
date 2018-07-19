using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Plane))]
public class PlaneControl : MonoBehaviour {

    Plane m_Aeroplane = null;

	// Use this for initialization
	void Start () {
        if (m_Aeroplane == null) m_Aeroplane = GetComponent<Plane>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float pitch = CrossPlatformInputManager.GetAxis("Vertical");
        bool airBrakes = CrossPlatformInputManager.GetButton("Fire1");

        // auto throttle up, or down if braking.
        float throttle = airBrakes ? -1 : 1;

        // Pass the input to the aeroplane
        m_Aeroplane.Move(pitch, throttle, airBrakes);
    }
}
