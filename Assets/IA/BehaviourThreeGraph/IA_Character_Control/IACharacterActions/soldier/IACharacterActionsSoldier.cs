using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsSoldier : IACharacterActionsHuman
{

    float FrameRate = 0;
    public float Rate=1;
    public int damage = 1;
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    public void Attack()
    {
        if (FrameRate > Rate)
        {
            FrameRate = 0;
            AIEye.ViewEnemy.Damage(damage, this.health);
            Debug.Log("Attack " + Time.time);
        }
        FrameRate += Time.deltaTime;


    }
    
}
