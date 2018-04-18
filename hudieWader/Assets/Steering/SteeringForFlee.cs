using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 离开行为
/// </summary>
public class SteeringForFlee : Steering {

    public GameObject target;
    /// <summary>
    /// 察觉到危险的距离
    /// </summary>
    public float fearDitance=20;
    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;
	// Use this for initialization
	void Start () {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
	}

    public override Vector3 Force()
    {
        // Vector3 tmpPos = new Vector3(transform.position.x, transform.position.y, 0);
        if (Vector3.Distance(transform.position, target.transform.position) > fearDitance)
        {
            return Vector3.zero;
        }
        desiredVelocity = (transform.position - target.transform.position).normalized * maxSpeed;
        return desiredVelocity-m_vehicle.velocity;
    }
}
