using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAAGun : Gun
{

    public GameObject target;
    public float towardsSpeed;
    public float fireRange = 50;
    // Use this for initialization
    void Start()
    {
        target = FindObjectOfType<PlayerPlane>().gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        {
            if (target != null)
            {
                Vector3 targetDir = target.transform.position - transform.position;

                // The step size is equal to speed times frame time.
                float step = towardsSpeed * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
                Debug.DrawRay(transform.position, transform.forward * fireRange, Color.red);

                // Move our position a step closer to the target.
                transform.rotation = Quaternion.LookRotation(newDir);
                RaycastHit hit;
                if (Physics.Raycast(muzzle.transform.position, muzzle.transform.TransformDirection(Vector3.forward), out hit, fireRange))
                {
                    if (hit.transform.CompareTag("Player"))
                        PullTrigger();
                }
            }
        }
    }
}
