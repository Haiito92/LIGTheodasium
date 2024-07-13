using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Movement))]
public class MovementEditor : Editor
{
    SerializedProperty _isPlayerProperty;
    SerializedProperty _speedProperty;
    SerializedProperty _movementInputProperty;
    SerializedProperty _waypointsProperty;

    private void OnEnable()
    {
        _isPlayerProperty = serializedObject.FindProperty("_isPlayer");
        _speedProperty = serializedObject.FindProperty("_speed");
        _movementInputProperty = serializedObject.FindProperty("_movementInput");
        _waypointsProperty = serializedObject.FindProperty("_waypoints");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_isPlayerProperty);
        EditorGUILayout.PropertyField(_speedProperty);


        if (_isPlayerProperty.boolValue)
        {
            EditorGUILayout.PropertyField(_movementInputProperty);
        }
        else
        {
            EditorGUILayout.PropertyField(_waypointsProperty);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
