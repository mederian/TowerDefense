using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemySpawner))]
public class WaveEditor : Editor
{
    /*
     * Number of enemies, slider 20 - 50, 25 as def
     * Default model
     * Colour variation of model
     * preview model - proly not happening
     * Size of model
     * armor value
     * hp value
     * damage value
     * (Text message when wave begin)
     * 
     * 
     * */
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EnemySpawner spawner = (EnemySpawner)target;

        if(GUILayout.Button("Add Enemy"))
        {
            spawner.AddWave();
            Debug.Log("We pressed generate enemey");
        }

        foreach(WaveComponent c in spawner.waveComps)
        {
            //EditorGUI.PropertyField(c.enemyPrefab, new GUIContent("Game Object"));
        }
    }
}
