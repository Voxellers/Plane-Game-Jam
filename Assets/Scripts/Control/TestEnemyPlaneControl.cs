using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyPlaneControl : TestPlaneControl
{
    //타겟이 있어야겠다.
    public GameObject targetToAttack;
    public float fireRange;
    void Start()
    {
        targetToAttack = FindObjectOfType<PlayerPlane>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Try2();
    }
    /*Try1 
        *앞으로 전진한다.
        *플레이어 방향으로 회전한다.
    */
    void Try1()
    {
        MoveForward();

        if (targetToAttack != null)
        {
            
        }
    }
    /*2
     * 앞으로 전진한다.
     * 플레이어 방향으로 회전한다.
     * 라인 트레이싱한다
     * 라인 트레이싱 했을 때 플레이어가 잡히는 순간 PullTrigger해서 총 쏜다.
     */
     void Try2()
    {
        MoveForward();
        RotateTowardTarget();
        Debug.DrawRay(transform.position, transform.forward * fireRange, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, fireRange))
        {
            if (hit.transform.CompareTag("Player"))
                PullTrigger();
        }
    }
    /*3
     * 앞으로 전진한다
     * 플레이어 방향으로 회전한다.
     * 라인 트레이싱 한다.
     * 라인 트레이싱 했을 때 플레이어가 잡히는 순간 PullTrigger를 한다.
     * 시간이 될 때 마다 
     */
     void Try3()
    { }

    void RotateTowardTarget()
    {
        var relativeUp = targetToAttack.transform.TransformDirection(Vector3.forward);
        var relativePos = targetToAttack.transform.position - transform.position;
        /*
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(relativePos, transform.up),
            rotateSpeed * Time.deltaTime);*/

        Vector3 newDir = Vector3.RotateTowards(transform.forward, relativePos, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir, this.transform.up);
    }
}
