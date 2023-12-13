using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionNotColliderAttack : ActionNodeRange
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;

        IAEyeAttack _IAEyeAttack = ((IAEyeAttack)_IACharacterVehiculo.AIEye);
        if (_IAEyeAttack!=null && !_IAEyeAttack.AttackDataView.Sight)

            return TaskStatus.Success;

        return TaskStatus.Failure;
    }


}