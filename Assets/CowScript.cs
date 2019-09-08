using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{
    public float force;
    private AudioSource audioSource;
    public List<AudioClip> ListOAudioClips;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ListOAudioClips = GameObject.Find("MOO").GetComponent<moos>().ListOfAudioClips;

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Alive" || col.gameObject.tag == "Wagon" || col.gameObject.tag == "NotAlive")
        {
            Debug.Log("DEAD");

            GetComponent<Rigidbody>().AddForce(Vector3.up * force);
            audioSource.clip = ListOAudioClips[Random.Range(0, ListOAudioClips.Count)];
            audioSource.Play();
        }
    }    
        
    

    void OnMouseDown()
    {
        audioSource.clip = ListOAudioClips[Random.Range(0, ListOAudioClips.Count)];
        audioSource.Play();
    }
}
