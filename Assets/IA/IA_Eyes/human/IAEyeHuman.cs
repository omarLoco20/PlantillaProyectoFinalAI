using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeHuman : IAEyeBase
{
    //public Health ViewAllie;// { get; set; }
    public int countSoldierView;
    public int countCivilView;
    public Health ViewAllie;
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public float DistanceAllied
    {
        get
        {
            return (this.ViewAllie != null) ? (transform.position - this.ViewAllie.transform.position).magnitude : -1;
        }
    }


    public Vector3 DirectionAllied
    {
        get
        {
            if (this.ViewAllie != null)
            {
                return (this.ViewAllie.transform.position - transform.position).normalized;
            }
            return Vector3.zero;
        }
    }

   
    public override void UpdateScan()
    {
        base.UpdateScan();
        

    }

   
    
}
