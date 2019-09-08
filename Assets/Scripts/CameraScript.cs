using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform TargetTransform;
    public float offset;

    void Update () {
        if(TargetTransform!=null)
		transform.position = new Vector3(transform.position.x,transform.position.y, TargetTransform.position.z + offset);
	}
}
