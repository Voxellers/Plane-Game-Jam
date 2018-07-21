using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject Bullet;
    public Transform Muzzle;
    public float shootPower;
    //Per Second
    public float fireRate = 0.25f;
    private float lastShootTime;

    private void Start()
    {
        lastShootTime = Time.time;
    }
    /**
     * Pull Trigger to shoot bullet.
     * we don't know it will work but anyway we trigger.
     * Check fire rate, and shoot it its right.
     **/
    public void PullTrigger()
    {
        if(Time.time > lastShootTime + fireRate)
        {
           var bullet=
                Instantiate(Bullet, Muzzle.position,
                Muzzle.rotation);
           //bullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shootPower);
           bullet.GetComponent<Rigidbody>().AddForce(Muzzle.forward * shootPower);
            lastShootTime = Time.time;
        }
    }
}
