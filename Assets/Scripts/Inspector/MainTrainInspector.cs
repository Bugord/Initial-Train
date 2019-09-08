using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR

using UnityEditor;

using UnityEngine;

[CustomEditor(typeof(TestScriptTrain))]
public class MainTrainInspector : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestScriptTrain myScript = (TestScriptTrain)target;
        if (GUILayout.Button("Add carriage"))
        {
            myScript.AddCarriage();
        }
        
    }
}
#endif
