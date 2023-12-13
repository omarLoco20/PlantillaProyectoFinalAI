using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionColliderRadioAction : ActionNodeRange
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.AIEye.ViewEnemy==null)
          return TaskStatus.Failure;
        IAEyeBase _IAEyeBase = ((IAEyeBase)_IACharacterVehiculo.AIEye);
        if (_IAEyeBase != null && _IAEyeBase.RadioActionDataView.Sight)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }


}