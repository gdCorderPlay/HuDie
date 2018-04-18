using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 追逐行为
/// </summary>
public class SteeringForPursuit : Steering {


    public GameObject target;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;



	void Start () {

        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
	}

    public override Vector3 Force()
    {

        Vector3 toTarget = target.transform.position - transform.position;

        float relativeDirection = Vector3.Dot(transform.forward, target.transform.forward);

        if (Vector3.Dot(toTarget, transform.forward) > 0 && relativeDirection < -0.95f)
        {
            desiredVelocity = toTarget.normalized * maxSpeed;
            return desiredVelocity - m_vehicle.velocity;

        }
        float lookaheadTime = toTarget.magnitude / (maxSpeed + target.GetComponent<Vehicle>().velocity.magnitude);
        desiredVelocity = (target.transform.position + target.GetComponent<Vehicle>().velocity * lookaheadTime - transform.position).normalized * maxSpeed;

        return desiredVelocity-m_vehicle.velocity;
    }
}
