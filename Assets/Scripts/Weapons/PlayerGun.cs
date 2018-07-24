using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun {

    [SerializeField] private CameraShake cameraShake;

    private  void Start()
    {
        base.Start();
        cameraShake = FindObjectOfType<CameraShake>().GetComponent<CameraShake>();
    }

    public override void PullTrigger()
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
            cameraShake.StartCoroutine(cameraShake.Shake());
        }
    }
}
