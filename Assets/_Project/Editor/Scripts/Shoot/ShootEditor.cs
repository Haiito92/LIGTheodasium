using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Shoot))]
public class ShootEditor : Editor
{
    SerializedProperty _isPlayerProperty;
    SerializedProperty _isStaticProperty;
    SerializedProperty _shootingDirectionsProperty;
    SerializedProperty _timeBetweenShootProperty;
    SerializedProperty _shootInputProperty;
    SerializedProperty _projectilePrefabProperty;
    SerializedProperty _spawnOffsetProperty;

    private void OnEnable()
    {
        _isPlayerProperty = serializedObject.FindProperty("_isPlayer");
        _isStaticProperty = serializedObject.FindProperty("_isStatic");
        _shootingDirectionsProperty = serializedObject.FindProperty("_shootingDirections");
        _timeBetweenShootProperty = serializedObject.FindProperty("_timeBetweenShoot");
        _shootInputProperty = serializedObject.FindProperty("_shootInput");
        _projectilePrefabProperty = serializedObject.FindProperty("_projectilePrefab");
        _spawnOffsetProperty = serializedObject.FindProperty("_spawnOffset");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_projectilePrefabProperty);
        EditorGUILayout.PropertyField(_spawnOffsetProperty);
        EditorGUILayout.PropertyField(_isPlayerProperty);

        if(_isPlayerProperty.boolValue)
        {
            EditorGUILayout.PropertyField(_shootInputProperty);
        }
        else
        {
            EditorGUILayout.PropertyField(_isStaticProperty);

            if(_isStaticProperty.boolValue)
            {
                EditorGUILayout.PropertyField(_shootingDirectionsProperty);
            }

            EditorGUILayout.PropertyField(_timeBetweenShootProperty);
        }

        serializedObject.ApplyModifiedProperties();

    }
}
