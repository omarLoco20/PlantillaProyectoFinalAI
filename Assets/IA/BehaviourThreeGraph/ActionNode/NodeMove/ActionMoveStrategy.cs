using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("MyAI/Move")]
public class ActionMoveStrategy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(_IACharacterVehiculo.health.IsDead)
            return TaskStatus.Failure;

        SwitchUnit();

        return TaskStatus.Success;

    }
    void SwitchUnit()
    {


        switch (_UnitGame)
        {
            case UnitGame.Zombie:
                
                break;
            case UnitGame.Soldier:
                if (_IACharacterVehiculo is IACharacterVehiculoSoldier)
                {
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).MoveToStrategy();
                    ((IACharacterVehiculoSoldier)_IACharacterVehiculo).LookEnemy();
                }
                break;
            case UnitGame.None:
                break;
            default:
                break;
        }



    }

}