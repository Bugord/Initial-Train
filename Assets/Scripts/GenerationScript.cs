using System.Collections.Generic;
using UnityEngine;


    public class GenerationScript : MonoBehaviour
    {
        public float currentZ = 0;
        public List<GameObject> listOfMapParts = new List<GameObject>();
        public GameObject player;

        public void GenerateNewPart()
        {
            GameObject newPart = Instantiate(listOfMapParts[Random.Range(0,listOfMapParts.Count)], transform.position + new Vector3(0,0,currentZ), Quaternion.LookRotation(-Vector3.right),transform);
            currentZ -= int.Parse(newPart.tag);

        }

        void Update()
        {
          //  Debug.Log((player.transform.position.z + 1000) +" : "+ currentZ);
          if(player!=null)
            if (player.transform.position.z - 2000 < currentZ) 
                GenerateNewPart();
        }
    }

