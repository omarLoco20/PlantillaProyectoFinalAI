using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEyeHuman : IAEyeBase
//{
//    //public Health ViewAllie;// { get; set; }
//    public int countSoldierView;
//    public int countCivilView;
//    public Health ViewAllie;
//    public Item Item;


//    public override void LoadComponent()
//    {
//        base.LoadComponent();
//    }

//    public float DistanceAllied
//    {
//        get
//        {
//            return (this.ViewAllie != null) ? (transform.position - this.ViewAllie.transform.position).magnitude : -1;
//        }
//    }


//    public Vector3 DirectionAllied
//    {
//        get
//        {
//            if (this.ViewAllie != null)
//            {
//                return (this.ViewAllie.transform.position - transform.position).normalized;
//            }
//            return Vector3.zero;
//        }
//    }


//    public override void UpdateScan()
//    {

//        if (Framerate > arrayRate[index])
//        {

//            index++;
//            index = index % arrayRate.Length;
//            this.Scan();
//            Framerate = 0;
//        }

//        Framerate += Time.deltaTime;

//        base.DataView();

//    }

//    public override void Scan()
//    {
//        if (health.HurtingMe != null) return;
//        ViewAllie = null;
//        ViewEnemy = null;

//        CountEnemyView = 0;
//        CountSoldierView = 0;
//        CountCivilView = 0;

//        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);

//        count = colliders.Length;


//        float min_dist = 10000000000f;

//        for (int i = 0; i < count; i++)
//        {

//            GameObject obj = colliders[i].gameObject;
//            Health Scanhealth = obj.GetComponent<Health>();

//            if (Scanhealth == null)
//                Debug.LogError("Scanhealth==null: " + (Scanhealth == null) + " obj name: " + obj.name);
//            else
//            if (this.IsNotIsThis(this.gameObject, obj))
//            {

//                if (obj.activeSelf &&
//                    !Scanhealth.IsDead &&
//                    Scanhealth.IsCantView &&
//                    mainDataView.IsInSight(Scanhealth.AimOffset))
//                {

//                    if (IsAllies(Scanhealth))
//                        this.ExtractViewAllied(ref min_dist, Scanhealth);
//                    else
//                       this.ExtractViewEnemy(ref min_dist, Scanhealth );
//                }
//            }
//        }
//    }
//    public void ExtractViewAllied(ref float min_dist, Health _health)
//    {
//                float dist = (transform.position - _health.transform.position).magnitude;
//                if (min_dist > dist)
//                {
//                    ViewAllie = _health;
//                    min_dist = dist;

//                }

//                if (_health._UnitGame == UnitGame.Soldier)
//                 countSoldierView++;
//                else
//                if (_health._UnitGame == UnitGame.Civil)
//                 countCivilView++;

//    }





//}
{
    public Health ViewAllie;
    public Item Item;
    public int countSoldierView;
    public int countCivilView;

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

        if (ViewEnemy != null)
        {
            if (((ViewEnemy.IsDead) || (!ViewEnemy.IsCantView)))
                ViewEnemy = null;
            else
                RadioActionDataView.IsInSight(ViewEnemy.AimOffset);
        }

        if (ViewEnemy == null)
        {
            mainDataView.Sight = false;
            RadioActionDataView.Sight = false;
        }

    }

    public override void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewAllie = null;
        ViewEnemy = null;
        Item = null;
        CountEnemyView = 0;
        countSoldierView = 0;
        countCivilView = 0;
        count = 0;

        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);

        count = colliders.Length;


        float min_dist = 10000000000f;

        for (int i = 0; i < count; i++)
        {

            GameObject obj = colliders[i].gameObject;

            if (this.IsNotIsThis(this.gameObject, obj))
            {

                Health Scanhealth = obj.GetComponent<Health>();
                if (Scanhealth != null &&
                    obj.activeSelf &&
                    !Scanhealth.IsDead &&
                    Scanhealth.IsCantView &&
                    mainDataView.IsInSight(Scanhealth.AimOffset))
                {


                    if (IsAllies(Scanhealth))
                    {
                        this.ExtractViewAllied(ref min_dist, Scanhealth);
                    }
                    else
                        base.ExtractViewEnemy(ref min_dist, Scanhealth);
                }
                else
                {
                    Item ScanItem = obj.GetComponent<Item>();
                    if (ScanItem != null)
                    {
                        Item = ScanItem;
                    }

                }

            }

        }
    }
    private void OnValidate()
    {
        mainDataView.CreateMesh();
        RadioActionDataView.CreateMesh();
    }
    private void OnDrawGizmos()
    {
        mainDataView.OnDrawGizmos();
        RadioActionDataView.OnDrawGizmos();
    }
    public void ExtractViewAllied(ref float min_dist, Health _health)
    {

        if (IsAllies(_health))
        {
            if (_health._UnitGame == UnitGame.Soldier)
            {
                float dist = (transform.position - _health.transform.position).magnitude;
                if (min_dist > dist)
                {
                    ViewAllie = _health;
                    min_dist = dist;

                }
                countSoldierView++;
            }
            else if (_health._UnitGame == UnitGame.Civil)
            {
                float dist = (transform.position - _health.transform.position).magnitude;
                if (min_dist > dist)
                {
                    ViewAllie = _health;
                    min_dist = dist;

                }
                countCivilView++;
            }
        }
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
}
