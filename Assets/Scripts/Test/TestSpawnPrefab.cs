using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawnPrefab : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private void OnGUI()
    {
        if (GUILayout.Button("Spawn"))
        {
            Instantiate(prefab);
        }
    }
}
