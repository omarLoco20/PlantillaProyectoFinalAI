using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoZombie : IACharacterVehiculo
{
    
    // Start is called before the first frame update
    void Start()
    {
        this.LoadComponent();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
       
    }
    
    public override void MoveToPosition(Vector3 pos)
    {
        base.MoveToPosition(pos);
    }
     
    public override void MoveToEnemy()
    {
        base.MoveToEnemy( );
    }
    public override void MoveToAllied()
    {
        base.MoveToAllied( );
    }
    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy( );
    }

}
