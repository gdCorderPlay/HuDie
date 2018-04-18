using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  分离行为 和群体的其它个体保持距离
/// </summary>
public class SteeringForSeparation : Steering {

    public float comfortDistance = 1;

    public float multiplierInsideComfortDistance = 2;

    private List<GameObject> neighbors;
    private void Start()
    {
        neighbors = new List< GameObject>();
    }
    public override Vector3 Force()
    {

        Vector3 steeringForce = Vector3.zero;
        neighbors = GetComponent<Radar>().neighbors;
        for(int i = 0; i < neighbors.Count; i++)
        {
            if(neighbors[i]!=null&&neighbors[i]!=this.gameObject)
            {
                Vector3 toNeighbor = transform.position - neighbors[i].transform.position;
                float length = toNeighbor.magnitude;
                steeringForce += toNeighbor.normalized / length;
                if (length < comfortDistance)
                {
                    steeringForce *= multiplierInsideComfortDistance;
                }
            }
        }
        return steeringForce;
    }
}
