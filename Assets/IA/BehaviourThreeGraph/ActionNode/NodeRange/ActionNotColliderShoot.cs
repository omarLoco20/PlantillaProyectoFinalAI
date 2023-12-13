using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionNotColliderShoot : ActionNodeRange
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;

        IAEyeShoot _IAEyeShoot = ((IAEyeShoot)_IACharacterVehiculo.AIEye);
        if (_IAEyeShoot != null && !_IAEyeShoot.ShootDataView.Sight)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }


}