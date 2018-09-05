using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Editor component of "Tower". Manages how the Tower component
/// info are displayed and modified in Unity Editor.
/// </summary>
[CustomEditor(typeof(PoolManager)), CanEditMultipleObjects]
public class PoolManagerEditor : Editor
{
    PoolManager pool;
    SerializedProperty logPoolStatusProp;
    SerializedProperty pooledObjsParentProp;

    SerializedProperty objPrefabsProp;
    SerializedProperty objAmountsProp;

    void OnEnable()
    {
        // Setup the SerializedProperties.
        pool = (PoolManager)target;
        logPoolStatusProp = serializedObject.FindProperty("logPoolStatus");
        pooledObjsParentProp = serializedObject.FindProperty("pooledObjsParent");

        objPrefabsProp = serializedObject.FindProperty("objPrefabs");
        objAmountsProp = serializedObject.FindProperty("objAmounts");

    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();


        EditorGUILayout.Separator();
        EditorGUILayout.PropertyField(logPoolStatusProp);
        EditorGUILayout.PropertyField(pooledObjsParentProp);

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Object Pools", EditorStyles.boldLabel);

        var values = EnumUtil.GetValues<PoolManager.PoolObject>();

        EditorGUILayout.Separator();

        foreach (var poolObj in values)
        {
            if ((int)poolObj >= pool.objPrefabs.Count) continue;

            SerializedProperty objPrefabProp = objPrefabsProp.GetArrayElementAtIndex((int)poolObj);
            SerializedProperty objAmountProp = objAmountsProp.GetArrayElementAtIndex((int)poolObj);

            EditorGUILayout.LabelField(poolObj.ToString(), EditorStyles.label);
            EditorGUILayout.PropertyField(objPrefabProp, new GUIContent("Prefab"));
            EditorGUILayout.IntSlider(objAmountProp, 0, 500, new GUIContent("Amount"));

            EditorGUILayout.Separator();
        }

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Objects defined at PoolManager.PoolObjects",
            EditorStyles.centeredGreyMiniLabel);

        EditorGUILayout.Separator();


        if (GUILayout.Button("Update Pool (" + pool.objPrefabs.Count + ")",
            EditorStyles.miniButton))
        {
            int objAmountEnum = Enum.GetNames(typeof(PoolManager.PoolObject)).Length;
            int diff = pool.objPrefabs.Count - objAmountEnum;
            
            if (diff < 0)
            {
                for (int i = 0; i < -diff; i++)
                {
                    pool.objPrefabs.Add(null);
                    pool.objAmounts.Add(0);
                }
            }
            else if(diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    pool.objPrefabs.RemoveAt(pool.objPrefabs.Count - 1);
                    pool.objAmounts.RemoveAt(pool.objAmounts.Count - 1);
                }
            }           
        }

        EditorGUILayout.Separator();
        EditorGUILayout.Separator();

        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.
        serializedObject.ApplyModifiedProperties();
    }
}