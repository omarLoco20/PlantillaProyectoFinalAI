using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IACharacterVehiculoHuman : IACharacterVehiculo
{
    protected Vector3 normales;

    public override void LoadComponent()
    {
        base.LoadComponent();
       
    }
    public override void LookEnemy()
    {
        base.LookEnemy();

       
    }
    public override void LookPosition(Vector3 position)
    {

        base.LookPosition(position);
    }
    public override void LookRotationCollider()
    {

        base.LookRotationCollider();
    }


    public override void MoveToPosition(Vector3 pos)
    {
       base.MoveToPosition(pos);
    }
    public override void MoveToEnemy()
    {
        base.MoveToEnemy();
    }
    public override void MoveToAllied()
    {
        if(AIEye is IAEyeHuman)
        {
            if (((IAEyeHuman)AIEye).ViewAllie == null) return;
            MoveToPosition(((IAEyeHuman)AIEye).ViewAllie.transform.position);
        }


       
    }


    public override void MoveToEvadEnemy()
    {
        base.MoveToEvadEnemy();
    }



   
    public override void MoveToWander()
    {
        base.MoveToWander();
    }

    public Vector3 ColliderWall()
    {
        normales = Vector3.zero;
        Ray[] arrayRay = new Ray[3];
        arrayRay[0] = new Ray(health.AimOffset.position, health.AimOffset.right);
        arrayRay[1] = new Ray(health.AimOffset.position, -health.AimOffset.forward);
        arrayRay[2] = new Ray(health.AimOffset.position, -health.AimOffset.right);
        for (int i = 0; i < 2; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(arrayRay[i], out hit, 3, AIEye.mainDataView.occlusionlayers))
            {
                normales += hit.normal;
            }
        }
        return normales;
    }

    public virtual void MoveToStrategy()
    {

        if (AIEye.ViewEnemy == null) return;
        Vector3 dir = Vector3.zero;
        normales = ColliderWall();
        if (normales != Vector3.zero)
            dir = normales;
        else
        {
            dir = (transform.position - AIEye.ViewEnemy.transform.position).normalized;
        }
        Vector3 newPosition = transform.position + dir * 2;
        MoveToPosition(newPosition);

        Debug.Log("ColliderWall " + normales);
    }

     




    public void DrawGizmos()
    {
        if (health == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, positionWander);
        
        Gizmos.DrawSphere(positionWander, 1.7f);

        Ray[] arrayRay = new Ray[3];
        arrayRay[0] = new Ray(health.AimOffset.position, health.AimOffset.right);
        arrayRay[1] = new Ray(health.AimOffset.position, -health.AimOffset.forward);
        arrayRay[2] = new Ray(health.AimOffset.position, -health.AimOffset.right);
        for (int i = 0; i < arrayRay.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(arrayRay[i], out hit, 3, AIEye.mainDataView.occlusionlayers))
            {
                Gizmos.color = Color.red;

            }
            else
            {
                Gizmos.color = Color.blue;
            }

            Gizmos.DrawLine(arrayRay[i].origin, arrayRay[i].origin + arrayRay[i].direction * 3f);
            Gizmos.DrawSphere(arrayRay[i].origin + arrayRay[i].direction * 3f, 0.7f);
        }


        Gizmos.color = Color.yellow;
        if (normales != Vector3.zero)
        {
            Gizmos.DrawLine(health.AimOffset.position, health.AimOffset.position + normales * 2f);
            Gizmos.DrawSphere(health.AimOffset.position + normales * 2f, 0.5f);
        }





    }
}
