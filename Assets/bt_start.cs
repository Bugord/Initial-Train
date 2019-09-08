using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt_start : MonoBehaviour
{
    public GameObject cameraMain;
    public GameObject cameraCurrent;
    public GameObject generator;

    void OnMouseDown()
    {
        cameraCurrent.SetActive(false);
        cameraMain.SetActive(true);
        generator.SetActive(true);
      // Debug.Log("Start!");
    }
}
