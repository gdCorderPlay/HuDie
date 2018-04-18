using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ai 角色的基类
/// </summary>
public class Vehicle : MonoBehaviour {
    /// <summary>
    /// 包含的行为列表
    /// </summary>
    private Steering[] steering;
    /// <summary>
    /// ai角色的最大速度
    /// </summary>
    [Header("最大速度")]
    public float maxSpeed = 10;
    /// <summary>
    /// 能接受的最大力
    /// </summary>
    [Header("可以被施加的最大力")]
    public float maxForce = 100;
    /// <summary>
    /// 最大速度的平方 预处理
    /// </summary>
    protected float sqrMaxSpeed;
    /// <summary>
    /// 角色的质量
    /// </summary>
    [Header("角色的质量")]
    public float mass = 1;
    /// <summary>
    /// 角色的速度
    /// </summary>
    [Header("角色的速度")]
    public Vector3 velocity;
    /// <summary>
    /// 角色转向时的速度
    /// </summary>
    [Header("角色转向时的速度")]
    public float damping = 0.9f;
    /// <summary>
    /// 操控力的计算时间间隔
    /// </summary>
    [Header("操控力计算的时间间隔")]
    public float computerInterval = 0.2f;
    /// <summary>
    /// 判断是否是在平面上如果是忽略z的不同
    /// </summary>
    [Header("是否在平面上")]
    public bool isPlanar = true;
    /// <summary>
    /// 计算得到的操控力
    /// </summary>
    private Vector3 steeringForce;
    /// <summary>
    /// ai角色的加速度
    /// </summary>
    protected Vector3 acceleration;
    /// <summary>
    /// 计时器
    /// </summary>
    private float timer;
	protected void Start ()
    {
        steeringForce = Vector3.zero;
        sqrMaxSpeed = maxSpeed * maxSpeed;
        timer = 0;

        steering = GetComponents<Steering>();
	}


    protected void Update ()
    {
        timer += Time.deltaTime;
        steeringForce = Vector3.zero;
        if (timer > computerInterval)//获取各种操控力的和
        {
            for(int i = 0; i < steering.Length; i++)
            {
                if(steering[i].enabled)
                {
                    steeringForce += steering[i].Force() * steering[i].weight;
                }
            }
            steeringForce = Vector3.ClampMagnitude(steeringForce, maxForce);
            acceleration = steeringForce / mass;
            timer = 0;
        }

		
	}
}
