using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeCactus : MonoBehaviour
{

    public float Radius;
    public float Force;
    public List<GameObject> Pieces;

    void Start()
    {
        //GetComponent<AudioSource>().Play();
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Pieces.Add(transform.GetChild(i).gameObject);
        //}
        
        Explode();
    }

    public void Explode()
    {
        for (int i = 0; i < Pieces.Count; i++)
        {
            Rigidbody rgbd = Pieces[i].GetComponent<Rigidbody>();
            rgbd.useGravity = true;
            rgbd.AddExplosionForce(Force, transform.position - Vector3.up*2 + Vector3.forward*5, Radius);
           // rgbd.AddForce(Vector3.up*Force);
        }
    }
}
