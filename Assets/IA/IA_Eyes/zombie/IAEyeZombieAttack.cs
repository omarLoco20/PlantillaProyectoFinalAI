using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeZombieAttack : IAEyeAttack
{
    
    private void Start()
    {
        LoadComponent();
    }

    private void Update()
    {
        UpdateScan();
    }
    public override void LoadComponent()
    {
        base.LoadComponent();
    }


    public override void UpdateScan()
    {
        if (Framerate > arrayRate[index])
        {

            index++;
            index = index % arrayRate.Length;
            this.Scan();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;

        base.DataView();

        if (ViewEnemy != null)
            AttackDataView.IsInSight(ViewEnemy.AimOffset);
        else
        {
            AttackDataView.Sight = false;
        }

    }
    public override void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewEnemy = null;

        CountEnemyView = 0;

        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);

        count = colliders.Length;


        float min_dist = 10000000000f;

        for (int i = 0; i < count; i++)
        {

            GameObject obj = colliders[i].gameObject;
            Health Scanhealth = obj.GetComponent<Health>();

            if (Scanhealth == null)
                Debug.LogError("Scanhealth==null: " + (Scanhealth == null) + " obj name: " + obj.name);
            else
            if (this.IsNotIsThis(this.gameObject, obj))
            {

                if (obj.activeSelf &&
                    !Scanhealth.IsDead &&
                    Scanhealth.IsCantView &&
                    mainDataView.IsInSight(Scanhealth.AimOffset))
                {
                    if (!IsAllies(Scanhealth))
                        this.ExtractViewEnemy(ref min_dist, Scanhealth);
                }
            }
        }
    }

    private void OnValidate()
    {
        mainDataView.CreateMesh();
        AttackDataView.CreateMesh();

    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        AttackDataView.OnDrawGizmos();
    }
}
