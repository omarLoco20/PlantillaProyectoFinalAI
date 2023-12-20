using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterActionsZombie : IACharacterActions
{

    float FrameRate = 0;
    public float Rate=1;
    public int damage = 1;
    public int countSpawn;
    public bool BoolReproduction = false;
    public float time = 20;
    IACharacterVehiculoZombie _IACharacterVehiculoZombie;
    private void Start()
    {
        LoadComponent();

    }


    public override void LoadComponent()
    {
        base.LoadComponent();
        _IACharacterVehiculoZombie = GetComponent<IACharacterVehiculoZombie>();

    }
    public void SpanwZombieAnt()
    {

        for (int i = 1; i <= countSpawn; i++)
        {
            if (ControlZombieManager.instance.CantAddZombie)
            {
                GameObject antZombie = FactoryManager.instance.CreateObjectZombie(transform);
                IACharacterVehiculoZombie v = antZombie.GetComponent<IACharacterVehiculoZombie>();
                if (v != null)
                {
                    v.destinoReproduccion = _IACharacterVehiculoZombie.destinoReproduccion;
                }

            }
            
        }

        ((helathSimpleZombie)health).Damage(100000, null);
    }
    public void Attack()
    {
        if(FrameRate>Rate)
        {
            FrameRate = 0;
            AIEye.ViewEnemy.Damage(damage, this.health);
          
        }
        FrameRate += Time.deltaTime;


    }

    private void Update()
    {
        if(!BoolReproduction)
         funcionReproduction();
    }
    public void funcionReproduction()
    {
        float guardador = time;
        time = time - 1 * Time.deltaTime;

     
        if (time <= 0)
        {
            time = guardador;
            BoolReproduction = true;
        }
    }
}
