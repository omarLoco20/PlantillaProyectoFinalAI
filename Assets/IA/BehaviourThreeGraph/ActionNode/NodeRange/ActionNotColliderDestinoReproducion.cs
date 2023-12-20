using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Range")]
public class ActionNotColliderDestinoReproducion : ActionNodeRange
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (_IACharacterActions is IACharacterActionsZombie)
        {
            if (((IACharacterActionsZombie)_IACharacterActions).BoolReproduction)
            {

                if(!((IACharacterVehiculoZombie)_IACharacterVehiculo).EnterDestinoRepsoducion())
                return TaskStatus.Success;

            }


        }

        return TaskStatus.Failure;
    }


}