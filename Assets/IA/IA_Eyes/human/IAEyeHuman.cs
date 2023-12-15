using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeHuman : IAEyeBase
{
    //public Health ViewAllie;// { get; set; }
    public int countSoldierView;
    public int countCivilView;
    public Health ViewAllie;
    

     
    public override void LoadComponent()
    {
        base.LoadComponent();
    }

    public float DistanceAllied
    {
        get
        {
            return (this.ViewAllie != null) ? (transform.position - this.ViewAllie.transform.position).magnitude : -1;
        }
    }


    public Vector3 DirectionAllied
    {
        get
        {
            if (this.ViewAllie != null)
            {
                return (this.ViewAllie.transform.position - transform.position).normalized;
            }
            return Vector3.zero;
        }
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

    }

    public override void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewAllie = null;
        ViewEnemy = null;

        CountEnemyView = 0;
        CountSoldierView = 0;
        CountCivilView = 0;

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

                    if (IsAllies(Scanhealth))
                        this.ExtractViewAllied(ref min_dist, Scanhealth);
                    else
                       this.ExtractViewEnemy(ref min_dist, Scanhealth );
                }
            }
        }
    }
    public void ExtractViewAllied(ref float min_dist, Health _health)
    {
                float dist = (transform.position - _health.transform.position).magnitude;
                if (min_dist > dist)
                {
                    ViewAllie = _health;
                    min_dist = dist;

                }

                if (_health._UnitGame == UnitGame.Soldier)
                 countSoldierView++;
                else
                if (_health._UnitGame == UnitGame.Civil)
                 countCivilView++;

    }


     


}
