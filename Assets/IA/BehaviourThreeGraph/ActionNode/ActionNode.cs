using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/BaseClass")]
public class ActionNode : Action
{

    protected IACharacterVehiculo _IACharacterVehiculo;
    protected IACharacterActions _IACharacterActions;
    protected UnitGame _UnitGame;
    public override void OnStart()
    {
        base.OnStart();
        _IACharacterVehiculo = GetComponent<IACharacterVehiculo>();
        _IACharacterActions = GetComponent<IACharacterActions>();
        _UnitGame = _IACharacterVehiculo.health._UnitGame;
    }

     
}