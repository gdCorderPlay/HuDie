using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {

            transform.position = ChangePos(transform.position);


        }

	}
    Vector3 ChangePos(Vector3 pos )
    {
       Vector3 screenPos=  Camera.main.WorldToScreenPoint(pos);
        screenPos.Set(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);

        return Camera.main.ScreenToWorldPoint(screenPos);
    }
}
