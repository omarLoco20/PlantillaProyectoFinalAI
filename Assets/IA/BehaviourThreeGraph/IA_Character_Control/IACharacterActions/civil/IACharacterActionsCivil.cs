using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IACharacterActionsCivil : IACharacterActionsHuman
{
    // NavMesh

    bool isFertil = false;
    int contadorDeCambioFertil;
     void Start()
    {
        this.LoadComponent();
    }
    public void Reproducion()
    {
        health._StateAnt = StateAnt.REPRODUCTION;
    }
    public void Eat()
    {
        health._StateAnt = StateAnt.EAT;

    }
    public void Work()
    {

    }
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    
}
