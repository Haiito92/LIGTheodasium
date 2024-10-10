using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Movement))]
public class MovementEditor : Editor
{
    SerializedProperty _isPlayerProperty;
    SerializedProperty _movingTransformProperty;
    SerializedProperty _movingAnimatorProperty;
    SerializedProperty _speedProperty;
    SerializedProperty _movementInputProperty;
    SerializedProperty _waypointsProperty;

    private void OnEnable()
    {
        _isPlayerProperty = serializedObject.FindProperty("_isPlayer");
        _movingTransformProperty = serializedObject.FindProperty("_movingTransform");
        _movingAnimatorProperty = serializedObject.FindProperty("_movingAnimator");
        _speedProperty = serializedObject.FindProperty("_speed");
        _movementInputProperty = serializedObject.FindProperty("_movementInput");
        _waypointsProperty = serializedObject.FindProperty("_waypoints");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_isPlayerProperty);
        EditorGUILayout.PropertyField(_movingTransformProperty);
        EditorGUILayout.PropertyField(_movingAnimatorProperty);
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
