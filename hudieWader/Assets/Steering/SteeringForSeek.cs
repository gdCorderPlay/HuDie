using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 靠近行为
/// </summary>
public class SteeringForSeek : Steering {
    /// <summary>
    /// 靠近行为的目标点
    /// </summary>
    [Header("靠近的目标")]
    public GameObject target;
    /// <summary>
    /// 预期速度
    /// </summary>
    private Vector3 desiredVelocity;
    /// <summary>
    /// 被操控的角色
    /// </summary>
    private Vehicle m_vehicle;
    /// <summary>
    /// 最大速度
    /// </summary>
    private float maxSpeed;
    /// <summary>
    /// 是否仅在平面上运动
    /// </summary>
    private bool isPlanar;

    private void Start()
    {

        m_vehicle = this.gameObject.GetComponent<Vehicle>();

        maxSpeed = m_vehicle.maxSpeed;

        isPlanar = m_vehicle.isPlanar;


    }
    public override Vector3 Force()
    {
        desiredVelocity = (target.transform.position - transform.position).normalized*maxSpeed;

        if (isPlanar)
        {
            desiredVelocity.z = 0;

        }

        return desiredVelocity-m_vehicle.velocity;
    }

}
