using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarriageScriptTest : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Alive")
        {
            GameObject go = GameObject.FindWithTag("Alive");
            if (go != null)
                go.GetComponent<TestScriptTrain>().RemoveCarriage(gameObject);
        }
    }
}
