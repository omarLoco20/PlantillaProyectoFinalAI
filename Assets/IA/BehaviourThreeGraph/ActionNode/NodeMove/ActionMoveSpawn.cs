using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionMoveSpawn : ActionNodeVehicle
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
                ((IACharacterVehiculoZombie)_IACharacterVehiculo).MoveToPositionSpawn();

            }


        }

        return TaskStatus.Success;

    }
     

}