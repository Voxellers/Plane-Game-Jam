using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : MonoBehaviour
{

    [SerializeField] private float healthPoint = 0f;
    //최대 헬스 포인트는 아이템등에 의해 변할 수 있으므로 public 함.
    public float maxHealthPoint = 100f;
    public bool isFullHealthOnStart = true;

    public void Start()
    {
        if (isFullHealthOnStart) healthPoint = maxHealthPoint;
    }

    public void SetHP(float newHealthPoint)
    {
        healthPoint = newHealthPoint;
        EventByDesiredHealthPoint(healthPoint);
    }
    public float GetHP()
    {
        return healthPoint;
    }

    /**
     * changed name : HPAction -> EventByDesiredHealthPoint
     * */
    protected virtual void EventByDesiredHealthPoint(float hp)
    {
        {
            if (hp <= 0)
                Destroy(gameObject);
        }
    }
}
