using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class spawnFood : spawnItem
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItem());
    }

    public override void DiscountItem()
    {
        base.DiscountItem();

    }

    private void OnDrawGizmos()
    {
        base.DrawGizmos();
    }
}

