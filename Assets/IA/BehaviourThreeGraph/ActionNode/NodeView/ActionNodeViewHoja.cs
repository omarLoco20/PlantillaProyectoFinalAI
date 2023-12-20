using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/View")]
public class ActionNodeViewHoja : ActionNodeView
{
     

    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterVehiculo.AIEye.ViewHoja == null)
        {
            return TaskStatus.Failure;

        }
        else
        {
            return TaskStatus.Success;

        }

    }


}