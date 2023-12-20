using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Action")]
public class ActionSpawnReproducion : ActionNodeVehicle
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

                ((IACharacterActionsZombie)_IACharacterActions).SpanwZombieAnt();
            }


        }

        return TaskStatus.Failure;

    }
    

}