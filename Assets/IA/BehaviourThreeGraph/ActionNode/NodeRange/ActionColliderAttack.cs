using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionColliderAttack : ActionNodeRange
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;
        if(_IACharacterVehiculo.AIEye is IAEyeShootAttack)
        {
            IAEyeShootAttack _IAEyeShootAttack = ((IAEyeShootAttack)_IACharacterVehiculo.AIEye);
            if (_IAEyeShootAttack != null && _IAEyeShootAttack.AttackDataView.Sight)
                return TaskStatus.Success;
        }
        else
        if (_IACharacterVehiculo.AIEye is IAEyeAttack)
        {
            IAEyeAttack _IAEyeAttack = ((IAEyeAttack)_IACharacterVehiculo.AIEye);
            if (_IAEyeAttack != null && _IAEyeAttack.AttackDataView.Sight)
                return TaskStatus.Success;
        }
        

        return TaskStatus.Failure;
    }


}