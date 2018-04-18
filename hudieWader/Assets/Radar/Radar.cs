using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 检测附近的角色
/// </summary>
public class Radar : MonoBehaviour {

    private Collider[] colliders;

    private float timer = 0;

    public List<GameObject> neighbors;
    /// <summary>
    /// 检测时间间隔
    /// </summary>
    public float checkInterval = 0.3f;
   /// <summary>
   /// 检测半径
   /// </summary>
    public float detectRadius = 10f;

    public LayerMask layersChecked;

	void Start () {

        neighbors = new List<GameObject>();

	}
	
	void Update () {
        timer += Time.deltaTime;
        if (timer > checkInterval)
        {
            neighbors.Clear();
            colliders = Physics.OverlapSphere(transform.position, detectRadius, layersChecked);
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].GetComponent<Vehicle>())
                {
                    neighbors.Add(colliders[i].gameObject);
                }
            }
            timer = 0;
        }
	}
}
