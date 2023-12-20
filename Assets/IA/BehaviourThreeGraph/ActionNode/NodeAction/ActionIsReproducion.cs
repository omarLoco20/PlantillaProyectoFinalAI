using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Action")]
public class ActionIsReproducion : ActionNodeVehicle
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
                return TaskStatus.Success;

            }


        }

        return TaskStatus.Failure;

    }
    

}