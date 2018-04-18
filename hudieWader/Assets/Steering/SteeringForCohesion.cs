using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 聚集行为
/// </summary>
public class SteeringForCohesion : Steering {

    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;
    private List<GameObject> neighbors;
  
    // Use this for initialization
    void Start () {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        neighbors = new List<GameObject>();
    }

    public override Vector3 Force()
    {
        Vector3 steeringForce = Vector3.zero;
        Vector3 centerOfMass = Vector3.zero;
        int neighborCount = 0;
        for(int i = 0; i < neighbors.Count; i++)
        {
            if (neighbors[i] != null && neighbors[i] != gameObject)
            {

                centerOfMass += neighbors[i].transform.position;
                neighborCount++;
            }

        }
        if (neighborCount > 0)
        {
            centerOfMass /= (float)neighborCount;
            desiredVelocity = (centerOfMass - transform.position).normalized * maxSpeed;
            steeringForce = desiredVelocity - m_vehicle.velocity;

        }


        return  steeringForce;
    }
}
