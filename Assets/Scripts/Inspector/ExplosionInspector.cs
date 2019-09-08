using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;

using UnityEngine;

[CustomEditor(typeof(ExplodeCactus))]

public class ExplosionInspector : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ExplodeCactus myScript = (ExplodeCactus)target;
        if (GUILayout.Button("BIGBADABUM"))
        {
            myScript.Explode();
        }

    }
}
#endif

