using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusScript : MonoBehaviour
{
    public GameObject ExplodionCactus;
    public bool press;
        private AudioSource audioSource;
        public List<AudioClip> ListOfAudioClips = new List<AudioClip>();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Cactus") 
        Bang();
    }

    void Bang()
    {
        GameObject.Find("Text").GetComponent<Score>().Add();
      

        var temp = Instantiate(ExplodionCactus, transform.position, Quaternion.Euler(transform.rotation.eulerAngles));
        temp.transform.parent = transform.parent;
        temp.transform.localScale = transform.localScale;
        audioSource.clip = ListOfAudioClips[Random.Range(0, ListOfAudioClips.Count)];
        audioSource.Play();
        transform.position += Vector3.down*-800;
        //Destroy(gameObject);
    }

    void OnMouseDown()
    {
        if(press)
        Bang();
    }
}
