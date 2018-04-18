using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 随机徘徊行为
/// </summary>
public class SteeringForWander : Steering {
    /// <summary>
    /// 徘徊半径
    /// </summary>
    public float wanderRadius;
    /// <summary>
    /// 徘徊距离
    /// </summary>
    public float wanderDistance;
    /// <summary>
    /// 最大徘徊速度
    /// </summary>
    public float wanderJitter;

    private bool isPlanar;

    private Vector3 desiredVelocity;
    private Vehicle m_vehicle;
    private float maxSpeed;
    private Vector3 circleTarget;
    private Vector3 wanderTarget;


	
	void Start () {
        m_vehicle = GetComponent<Vehicle>();
        maxSpeed = m_vehicle.maxSpeed;
        isPlanar = m_vehicle.isPlanar;
        circleTarget = new Vector3(wanderRadius * 0.707f, wanderRadius * 0.707f, 0);

	}

    public override Vector3 Force()
    {
        Vector3 randomDisplacement = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f) * wanderJitter * 2;
        if (isPlanar)
        {
            randomDisplacement.z = 0;
        }
        circleTarget += randomDisplacement;
        circleTarget = wanderRadius * circleTarget.normalized;
        wanderTarget = m_vehicle.velocity.normalized * wanderDistance + circleTarget + transform.position;
        desiredVelocity = (wanderTarget - transform.position).normalized * maxSpeed;
        return desiredVelocity - m_vehicle.velocity;
      
    }
}
