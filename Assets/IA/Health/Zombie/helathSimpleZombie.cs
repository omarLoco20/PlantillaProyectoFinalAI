using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helathSimpleZombie : healthZombie
{
    bool active=true;
    // Start is called before the first frame update
    void Start()
    {
        base.LoadComponent();
    }
    public override void Damage(int damage, Health enemy)
    {
        if (!active) return;
        base.Damage(damage, enemy);

        if(IsDead)
        {

            ControlZombieManager.instance.DeleteZombie(this);
            Destroy(this.gameObject);
        }


    }

}
