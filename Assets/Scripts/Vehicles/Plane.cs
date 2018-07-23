using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plane : Alive {

    [SerializeField] private float firstDangerPercent;
    [SerializeField] private float secondDangerPercent;
    private bool isFirstSmokeOn = false;
    private bool isSecondSmokeOn = false;
    public ParticleSystem firstSmoke;
    public ParticleSystem secondSmoke;


    public void Start()
    {
        base.Start();
    }

    protected override void EventByDesiredHealthPoint(float hp)
    {
        SetSmokeByHealthPoint(hp);

        if (hp <= 0)
            Destroy(gameObject);
    }
    
    protected void SetSmokeByHealthPoint(float hp)
    {
        float currentPercentage = hp / maxHealthPoint * 100;
        
        if(secondDangerPercent< currentPercentage && currentPercentage<= firstDangerPercent)
        {
            firstSmoke.Play();
            secondSmoke.Stop();
        }
        else if(currentPercentage <= secondDangerPercent)
        {
            firstSmoke.Stop();
            secondSmoke.Play();
        }
        else
        {
            firstSmoke.Stop();
            secondSmoke.Stop();
        }
    }
}
