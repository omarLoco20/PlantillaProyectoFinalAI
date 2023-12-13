using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DataViewBase
{
    #region RangeView


    [Header("----- RangeView -----")]
    [Range(0, 180)]
    public float angle = 30f;
    public float height = 1.0f;
    public Color meshColorOutSight = Color.red;
    public Mesh mesh;
    [SerializeField]
    protected float distance = 0f;
    public float Distance { get => distance; set => distance = value; }

    [Header("----- Owner ----- ")]
    public Health Owner;


    #endregion
    [Header("----- DrawGizmo ----- ")]
    public bool IsDrawGizmo = false;

    [Header("----- LayerMask ----- ")]
    public LayerMask Scanlayers;
    public DataViewBase()
    { }
    public virtual bool IsInSight(Transform enemy)
    {
        return false;
    }
    public void CreateMesh()
    {
        mesh = CreateWedgeMesh();
    }
    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();
        int segments = 10;
        int numTriangles = (segments * 4) + 4;
        int numVertices = numTriangles * 3;
        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;

        int vert = 0;

        // left side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        // right side
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomRight;
        vertices[vert++] = bottomCenter;

        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;
        for (int i = 0; i < segments; ++i)
        {
            bottomLeft = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * distance;
            bottomRight = Quaternion.Euler(0, currentAngle + deltaAngle, 0) * Vector3.forward * distance;

            topRight = bottomRight + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;

            // far side
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;
            vertices[vert++] = topRight;

            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;
            vertices[vert++] = bottomLeft;
            // top 
            vertices[vert++] = topCenter;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;
            // bottom 
            vertices[vert++] = bottomCenter;
            vertices[vert++] = bottomRight;
            vertices[vert++] = bottomLeft;

            currentAngle += deltaAngle;

        }


        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;

    }
    public virtual void OnDrawGizmos()
    {
        if (!IsDrawGizmo) return;

        if (mesh != null && Owner != null)
        {
            Gizmos.color = meshColorOutSight;
            Gizmos.DrawMesh(mesh, Owner.transform.position, Owner.transform.rotation);
        }
    }
}
[System.Serializable]
public class DataView : DataViewBase
{

    public LayerMask occlusionlayers;

    public bool Sight = false;

    public Color meshColorInSight = Color.red;

    [Header("InsideObject")]
    public bool InsideObject = true;

    public DataView()
    { }

    public override bool IsInSight(Transform AimOffset)
    {
        Sight = false;
        if (AimOffset == null) return false;

        Vector3 origin = Owner.AimOffset.position;
        Vector3 dest = AimOffset.position;
        Vector3 direcction = dest - origin;


        if (direcction.magnitude > distance)
            return Sight;

        if (dest.y < -(height + Owner.transform.position.y) || dest.y > (height + Owner.transform.position.y))
        {
            return Sight;
        }

        direcction.y = 0;
        float deltaAngle = Vector3.Angle(direcction.normalized, Owner.transform.forward);
        if (deltaAngle > angle)
        {
            return Sight;
        }

        if (Physics.Linecast(origin, dest, occlusionlayers) && InsideObject)
        {
            return Sight;
        }
        Sight = true;
        return Sight;
    }
    public override void OnDrawGizmos()
    {
        if (!IsDrawGizmo) return;

       
        if (mesh != null && Owner != null)
        {
            if (Sight)
            {
                Gizmos.color = meshColorInSight;
            }
            else
                Gizmos.color = meshColorOutSight;

            Gizmos.DrawMesh(mesh, Owner.transform.position, Owner.transform.rotation);
        }


    }
}
 

public class IAEyeBase : MonoBehaviour
{
    protected int count = 0;
    // protected Collider[] colliders = new Collider[10];
    public DataView mainDataView = new DataView();
    public DataView RadioActionDataView = new DataView();
    public int CountEnemyView = 0;
    #region Rate
    protected int index = 0;
    protected float[] arrayRate;
    protected int bufferSize = 10;
    public float randomWaitScandMin = 1;
    public float randomWaitScandMax = 1;


    protected float Framerate = 0;
    #endregion
    public Health health { get; set; }

    public bool IsDrawGizmo = false;
    public Transform AimOffset;
    public Health ViewEnemy;
    public Health ViewAllie;// { get; set; }

    public Vector3 Target { get; set; }

   
    

    #region Direction and Distance
    public float DistanceEnemy
    {
        get
        {
            return (this.ViewEnemy != null) ? (transform.position - this.ViewEnemy.transform.position).magnitude : -1;
        }
    }
    public Vector3 DirectionEnemy
    {
        get
        {
            if (this.ViewEnemy != null)
            {
                return (this.ViewEnemy.transform.position - transform.position).normalized;
            }
            return Vector3.zero;
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
     
    public float DistanceTarget
    {
        get
        {
            return (transform.position - this.Target).magnitude;
        }
    }
    public Vector3 DirectionTarget
    {
        get
        {
            return (Target - transform.position).normalized;
        }
    }
    #endregion

    // Start is called before the first frame update


    public virtual void LoadComponent()
    {
        health = GetComponent<Health>();
        mainDataView.Owner = health;
        Framerate = 0;
        index = 0;
        arrayRate = new float[bufferSize];
        for (int i = 0; i < arrayRate.Length; i++)
        {
            arrayRate[i] = (float)UnityEngine.Random.Range(randomWaitScandMin, randomWaitScandMax);
        }
    }

    public virtual void UpdateScan()
    {

        if (Framerate > arrayRate[index])
        {

            index++;
            index = index % arrayRate.Length;
            Scan();
            Framerate = 0;
        }

        Framerate += Time.deltaTime;

        if (ViewEnemy != null && ((ViewEnemy.IsDead) || (!ViewEnemy.IsCantView)))
        {
            ViewEnemy = null;
        }

    }

    public virtual void Scan()
    {
        if (health.HurtingMe != null) return;
        ViewAllie = null;
        ViewEnemy = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, mainDataView.Distance, mainDataView.Scanlayers);
        CountEnemyView = 0;
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
                    ExtractViewEnemy(ref min_dist, Scanhealth);
                }

            }



        }

    }

    private void ExtractViewEnemy(ref float min_dist, Health _health)
    {
        
        if (!IsAllies(_health))
        {
             
            float dist = (transform.position - _health.transform.position).magnitude;
            if (min_dist > dist)
            {
                ViewEnemy = _health;
                min_dist = dist;
                 
            }
            CountEnemyView++;
        }
        //else
        //if (_health.gameObject.CompareTag("Player"))
        //{
        //    if (ViewAllie == null)
        //        ViewAllie = _health;
        //}

    }

    public virtual bool IsAllies(Health heatlhScan)
    {
        for (int j = 0; (health != null && j < health.typeAgentAllies.Count); j++)
        {
            if (health.typeAgentAllies[j] == heatlhScan.typeAgent)
            {
                return true;
            }
        }

        return false;
    }

    public virtual bool IsNotIsThis(GameObject obj1, GameObject obj2)
    {

        return (obj1.GetInstanceID() != obj2.GetInstanceID());
    }

}

