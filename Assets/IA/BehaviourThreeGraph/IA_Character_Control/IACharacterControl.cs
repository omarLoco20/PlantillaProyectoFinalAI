using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class IACharacterControl : MonoBehaviour
{
    public NavMeshAgent agent { get; set; }
    public Health health { get; set; }
    public IAEyeBase AIEye { get; set; }

  //  public zombieReproduccion {get; set;}

    public virtual void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        AIEye = GetComponent<IAEyeBase>();

    }
}
