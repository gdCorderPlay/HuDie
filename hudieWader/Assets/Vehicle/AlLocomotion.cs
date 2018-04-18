using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制角色移动的类
/// </summary>
public class AlLocomotion : Vehicle {
    /// <summary>
    /// ai 的角色控制器
    /// </summary>
    private CharacterController controller;
    /// <summary>
    /// ai 角色的刚体组件
    /// </summary>
    private Rigidbody theRigidbody;
    /// <summary>
    /// ai 角色每次的移动距离
    /// </summary>
    private Vector3 moveDistance;

	
	new void Start () {
        controller = this.gameObject.GetComponent<CharacterController>();

        theRigidbody = this.gameObject.GetComponent<Rigidbody>();
        moveDistance = Vector3.zero;

        base.Start();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        velocity += acceleration * Time.fixedDeltaTime;//计算速度
        if (velocity.sqrMagnitude > sqrMaxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        moveDistance = velocity * Time.fixedDeltaTime; //计算移动距离
        if (isPlanar) //忽略深度 
        {

            velocity.z = 0;
            moveDistance.z = 0;
        }
        if (controller)
        {
            controller.SimpleMove(velocity);
        }else if (theRigidbody==null||theRigidbody.isKinematic)
        {

            transform.position += moveDistance;
        }else
        {
            theRigidbody.MovePosition(theRigidbody.position+moveDistance);
        }
        if (velocity.sqrMagnitude > 0.00001f)//更新朝向
        {
            Vector3 newForward = Vector3.Slerp(transform.forward, velocity, damping * Time.deltaTime);

            if (isPlanar)
            {
                newForward.z = 0;
            }
            transform.forward = newForward;
        }

	}
    private void OnTriggerEnter(Collider c )
    {
        if (c.CompareTag("limit"))
        {
            velocity = (Vector3.zero - transform.position).normalized * maxSpeed;
            velocity.z = 0;
        }
        

    }

}
