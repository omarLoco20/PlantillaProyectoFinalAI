using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionNodeViewItem : ActionNodeView
{


    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo is IACharacterVehiculoHuman)
        {
            IAEyeHuman _IAEyeHuman = (IAEyeHuman)((IACharacterVehiculoHuman)_IACharacterVehiculo).AIEye;
            if (_IAEyeHuman.Item != null)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;


    }


}