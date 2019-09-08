using System.Collections;
using System.Collections.Generic;
using Assets;
#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GenerationScript))]

public class MapGeneratorInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GenerationScript myScript = (GenerationScript)target;
        if (GUILayout.Button("new part"))
        {
            myScript.GenerateNewPart();
        }

    }
}
#endif
