using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeAttack : IAEyeBase
{
    public DataView AttackDataView = new DataView();
    
    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        base.UpdateScan();
        if (ViewEnemy != null)
            AttackDataView.IsInSight(ViewEnemy.AimOffset);
        else
        {
            AttackDataView.Sight = false;
            mainDataView.Sight = false;
        }

    }
     
}
