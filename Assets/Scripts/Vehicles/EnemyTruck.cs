using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTruck : Alive {
    private EnemyAAGun gun;
    public float forwardSpeed;
    //시즈모드 할 수 있냐?
    public bool isStationary = false;
    //시즈모드 했냐?
    public bool isSieged = false;
    public float siegeRange = 300;
    float direction = 1f;


    private void Start()
    {
        base.Start();
        gun = gameObject.GetComponentInChildren<EnemyAAGun>();
    }
    // Update is called once per frame
    void Update () {
        //일정 거리 이하인지 감지
        //멈추기
        if(isStationary && !isSieged && gun.target != null)
        {
            float distance = Vector3.Distance(transform.position, gun.target.transform.position);
            if(distance <= siegeRange)
            {
                isSieged = true;
            }
        }
        if(!isSieged)
        transform.position = transform.position + transform.forward *forwardSpeed* direction * Time.deltaTime;
        //오른쪽으로 계속 움직이기
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            direction *= -1f;
        }
    }
}
