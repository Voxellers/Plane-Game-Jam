using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyPlaneControl : TestPlaneControl
{
    //타겟이 있어야겠다.
    public GameObject targetToAttack;

    void Start()
    {
        targetToAttack = FindObjectOfType<PlayerPlane>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        Try1();

        /*2
         * 플레이어를 한 번 공격하고 난 뒤엔 벽에 부딪히지 않게만 직진비행한다.
         * 벽과 부딪힐 것 같으면 한바퀴 회전해 방향을 바꾸고 계속 직진비행한다.
         * 직진비행 시간이 어느정도 끝나면 다시 플레이어를 쫒아온다.
         */
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
}
