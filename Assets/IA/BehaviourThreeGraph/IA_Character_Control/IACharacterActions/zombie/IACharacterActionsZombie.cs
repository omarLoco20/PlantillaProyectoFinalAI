using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZombie : IACharacterActions
{

    float FrameRate = 0;
    public float Rate=1;

    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {
        if(FrameRate>Rate)
        {
            FrameRate = 0;
            Debug.Log("Attack "+Time.time);
        }
        FrameRate += Time.deltaTime;


    }
}
