using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoHuman : IACharacterVehiculo
{
   
    public override void LoadComponent()
    {
        base.LoadComponent();
       
    }
    public override void LookEnemy()
    {
        base.LookEnemy();

       
    }
    public override void LookPosition(Vector3 position)
    {

        base.LookPosition(position);
    }
    public override void LookRotationCollider()
    {

        base.LookRotationCollider();
    }


    public override void MoveToPosition(Vector3 pos)
    {
       base.MoveToPosition(pos);
    }
    public override void MoveToEnemy()
    {
        base.MoveToEnemy();
    }
    public override void MoveToAllied()
    {
        if(AIEye is IAEyeHuman)
        {
            if (((IAEyeHuman)AIEye).ViewAllie == null) return;
            MoveToPosition(((IAEyeHuman)AIEye).ViewAllie.transform.position);
        }


       
    }


    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy();
    }



   
    public override void MoveToWander()
    {
        base.MoveToWander();
    }
}
