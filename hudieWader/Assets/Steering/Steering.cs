using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 行为基类
/// </summary>
public abstract class Steering : MonoBehaviour {

    [Header("操控力的权重")]
    public float weight = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual Vector3 Force()
    {

        return Vector3.zero;
    }
}
