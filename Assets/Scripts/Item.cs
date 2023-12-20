using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Item : MonoBehaviour
{

    protected float FrameRate = 0;
    protected float Rate;
    public float MinRate;
    public float MaxRate;
    public UnityEvent eventInvoke;
    public LayerMask layerCollider;
    public bool Infinity = false;

    public spawnPoint _SpawnPoint { get; set; }
    public void LoadArrayRate()
    {

        Rate = Random.Range(MinRate, MaxRate);

    }
    public void DestroyItem()
    {

        eventInvoke.Invoke();
        if (_SpawnPoint != null)
            _SpawnPoint.Active = false;
        Destroy(this.gameObject);
    }
}