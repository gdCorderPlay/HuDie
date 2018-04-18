using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 队列 行为
/// </summary>
public class SteeringForAlignment : Steering {

  

    private List<GameObject> neighbors;
    private void Start()
    {
        neighbors = new List<GameObject>();
    }
    public override Vector3 Force()
    {

        Vector3 averageDirection = Vector3.zero;
        int neighborCount = 0;
        neighbors = GetComponent<Radar>().neighbors;
        for (int i = 0; i < neighbors.Count; i++)
        {
            if (neighbors[i] != null && neighbors[i] != this.gameObject)
            {
                averageDirection += neighbors[i].transform.forward;
                neighborCount++;
            }
        }
        if (neighborCount > 0)
        {
            averageDirection /= (float)neighborCount;
            averageDirection -= transform.forward;
        }

        return averageDirection;
    }
}
