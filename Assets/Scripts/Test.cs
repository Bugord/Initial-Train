using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject train;
    public GameObject TrainGameObject;
    public GameObject Camera;
    public GameObject newTrain;

    void Start()
    {
       Generate();
    }

    public void Generate()
    {
        if(GameObject.FindWithTag("Alive")!=null)
            return;
        newTrain = Instantiate(train, transform.position, Quaternion.Euler(0, -90, 0), TrainGameObject.transform);
        Camera.GetComponent<CameraScript>().TargetTransform = newTrain.transform;
        GameObject map = GameObject.Find("Map");
        map.GetComponent<GenerationScript>().player = newTrain;
        for (int i = 0; i < map.transform.childCount; i++)
        {
            Destroy(map.transform.GetChild(i).gameObject);
        }
        map.GetComponent<GenerationScript>().currentZ = 0;

    }

    public void Delete()
    {
        while (TrainGameObject.transform.childCount!=0)
        {
            Destroy(TrainGameObject.transform.GetChild(0));
        }
        Generate();
    }
}
