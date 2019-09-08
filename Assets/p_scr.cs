using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p_scr : MonoBehaviour
{
    private Rigidbody rbd;

    public float speed;
	// Use this for initialization
	void Start ()
	{
	    rbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rbd.AddForce(-transform.right * speed);
	}
}
