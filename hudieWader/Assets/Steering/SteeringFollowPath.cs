using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 路径跟随
/// </summary>
public class SteeringFollowPath : Steering {

    public GameObject[] wayPoints;
    private Transform target;
    private int currentNode;
    public float arriveDistance=1;
    private float sqrArriveDistance;
    private int numberOfNodes;
  
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;
    private bool isPlanar;
    public float slowDownDistance;


	void Start () {
        numberOfNodes = wayPoints.Length;
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
        currentNode = 0;
        target = wayPoints[currentNode].transform;
        sqrArriveDistance = arriveDistance * arriveDistance;
	}

    public override Vector3 Force()
    {
       
        Vector3 dist = target.position - transform.position;
        if (isPlanar)
        {
            dist.z = 0;
        }
        if (currentNode == numberOfNodes - 1)
        {
            if (dist.magnitude > slowDownDistance)
            {
                desiredVelocity = dist.normalized * maxSpeed;
                return desiredVelocity - m_vehicle.velocity;
            }
            else
            {
                desiredVelocity = dist - m_vehicle.velocity;
                return desiredVelocity - m_vehicle.velocity;
            }

        }
        else
        {

            if (dist.sqrMagnitude < sqrArriveDistance)
            {
                currentNode++;
                target = wayPoints[currentNode].transform;

            }
            desiredVelocity = dist.normalized * maxSpeed;
            return desiredVelocity - m_vehicle.velocity;
        }
      
    }
}
