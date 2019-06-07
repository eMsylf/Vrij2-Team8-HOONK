using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraMountEditor : Editor {
    public override void OnInspectorGUI() {
        EditorGUILayout.HelpBox("Note: you can adjust the camera angle by moving the outer mount vertically, and rotating the inner mount around the X axis.", MessageType.Info, true);
        DrawDefaultInspector();
        //EditorGUILayout.HelpBox("What is this", MessageType.Info);
    }
}
