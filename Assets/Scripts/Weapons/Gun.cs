﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public Transform muzzle;
    public ParticleSystem muzzleFlash;
    public AudioSource fireSound;
    public AudioClip fireSoundClip;
    public float shootPower;
    //Per Second
    public float fireRate = 0.25f;
    protected float lastShootTime;

    protected void Start()
    {
        lastShootTime = Time.time;
    }
    /**
     * Pull Trigger to shoot bullet.
     * we don't know it will work but anyway we trigger.
     * Check fire rate, and shoot it its right.
     **/
    public virtual void PullTrigger()
    {
        if (Time.time > lastShootTime + fireRate)
        {
            var inst =
                 Instantiate(bullet, muzzle.position,
                 muzzle.rotation);
            //inst.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * shootPower);
            inst.GetComponent<Rigidbody>().AddForce(muzzle.forward * shootPower);
            lastShootTime = Time.time;
            if (muzzleFlash != null)
                muzzleFlash.Play();
            if (fireSound != null)
            {
                fireSound.pitch = Random.Range(0.75f, 1);
                fireSound.PlayOneShot(fireSoundClip);
            }
        }
    }
}
