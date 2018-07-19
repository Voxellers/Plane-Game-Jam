using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alive : VoxObject
{
    float _hp = 0f;

    [SerializeField]
    private float healthPoint;

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
    protected virtual void EventByDesiredHealthPoint(float hp) { }
}
