using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDiffuse : MonoBehaviour
{

    public FuzzyFunction cerca = new FuzzyFunction();
    public FuzzyFunction medio = new FuzzyFunction();
    public FuzzyFunction lejos = new FuzzyFunction();
    public float speedRotation;
    
    public float DistanceRay;
    public Transform pointSensor;
    public LayerMask mask;

    public RaycastHit hit;
    public bool Collider { get; set; }

    public bool IsGizmos;
    public Color ColorGizmos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(pointSensor.position, pointSensor.forward, out hit, DistanceRay, mask))
        {
            Collider = true;
            
            CalculateAngle(hit.distance);
        }
        else
        {
            speedRotation = 0;
            Collider = false;
             
        }
           

    }

    void CalculateAngle(float front)
    {


        speedRotation = (cerca.Evaluate(front) * cerca.Singleton +
                    medio.Evaluate(front) * medio.Singleton +
                    lejos.Evaluate(front) * lejos.Singleton) /
                    (cerca.F_y + medio.F_y + lejos.F_y);

    }
    private void OnDrawGizmos()
    {
        if (!IsGizmos) return;
        Gizmos.color = ColorGizmos;
        Vector3 pos = pointSensor.position + pointSensor.forward * DistanceRay;
        Gizmos.DrawSphere(pos, 0.2f);
        Gizmos.DrawLine(pointSensor.position, pos);

        if(Collider)
        {
            Vector3 posNormal = hit.point + hit.normal*2;
            Gizmos.DrawSphere(posNormal, 0.2f);
            Gizmos.DrawLine(hit.point, posNormal);

        }


    }
}
