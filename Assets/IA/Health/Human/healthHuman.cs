using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthHuman : Health
{

    [Header("Food")]
    public float Food;
    //[Header("Water")]
    //public float Water;
    public override void LoadComponent()
    {
        base.LoadComponent();
        Food  = 50;
    }
    public void SetFood(float food)
    {
        Food += food;
    }
    
    public void UpdateHunger()
    {
        Food -= 0.5f;
    }
   
    
}
