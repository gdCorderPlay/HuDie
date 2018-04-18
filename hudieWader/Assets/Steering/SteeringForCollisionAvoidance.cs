using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 避开障碍物的行为
/// </summary>
public class SteeringForCollisionAvoidance : Steering {

    private bool isPlanar;

    private Vector3 desiredVelocity;

    private Vehicle m_vehicle;

    private float maxSpeed;
    private float maxForce;

    public float avoidanceForce;

    public float MAX_SEE_AHEAD = 2;
    private GameObject[] allColliders;


	// Use this for initialization
	void Start () {

        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        maxForce = m_vehicle.maxForce;
        isPlanar = m_vehicle.isPlanar;
        if (avoidanceForce > maxForce)
        {
            avoidanceForce = maxForce;
        }
        allColliders = GameObject.FindGameObjectsWithTag("limit");

	}

    public override Vector3 Force()
    {
        RaycastHit hit;
        Vector3 force = Vector3.zero;
        Vector3 velocity = m_vehicle.velocity;
        Vector3 normalizedVelocity = velocity.normalized;

        if(Physics.Raycast(transform.position,normalizedVelocity,out hit,MAX_SEE_AHEAD*velocity.magnitude/maxSpeed))
        {
            Vector3 ahead = transform.position + normalizedVelocity * MAX_SEE_AHEAD * (velocity.magnitude / maxSpeed);
            force = ahead - hit.collider.transform.position;
            force *= avoidanceForce;
            if (isPlanar)
            {
                force.z = 0;
            }
        }

        return force;
    }
}
