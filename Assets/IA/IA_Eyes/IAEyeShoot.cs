using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeShoot : IAEyeHuman
{
    public DataView ShootDataView = new DataView();

    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        base.UpdateScan();
        if (ViewEnemy != null)
        {
            ShootDataView.IsInSight(ViewEnemy.AimOffset);
        }
        else
        {
            ShootDataView.Sight = false;
        }

    }
     
}
