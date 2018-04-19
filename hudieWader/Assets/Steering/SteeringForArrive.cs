using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 抵达 行为
/// </summary>
public class SteeringForArrive : Steering {
    /// <summary>
    /// 抵达的目标
    /// </summary>
    public GameObject target;
    private bool isPlanar ;

    /// <summary>
    /// 判断为抵达的距离
    /// </summary>
    public float arriveDistance = 0.3f;
    /// <summary>
    /// 角色的半径
    /// </summary>
   // public float characterRadius = 1.2f;
    /// <summary>
    /// 开始减速的距离
    /// </summary>
    public float slowDownDistance;
   
    private Vector3 desireVelocity;

    private Vehicle m_Vehicle;
    private float maxSpeed;

	// Use this for initialization
	void Start () {

        m_Vehicle = this.gameObject.GetComponent<Vehicle>();
        maxSpeed = m_Vehicle.maxSpeed;
        isPlanar = m_Vehicle.isPlanar;

	}

    public override Vector3 Force()
    {
        Vector3 toTarget = target.transform.position - transform.position;

        if (isPlanar)
        {
            toTarget.z = 0;
        }
        if (toTarget.magnitude > slowDownDistance)
        {
            desireVelocity = toTarget.normalized * maxSpeed;
            return desireVelocity - m_Vehicle.velocity;
        }else
        {
            desireVelocity = toTarget - m_Vehicle.velocity;
            return desireVelocity - m_Vehicle.velocity;
        }
        
    }



}
