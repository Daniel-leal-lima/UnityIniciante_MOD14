using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingZone : MonoBehaviour
{
    [SerializeField] GameObject finishPrefab;
    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        Mesh combinedMesh = MeshCombiner.Combine(meshFilters, transform, false);
        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = combinedMesh;
        mc.convex = true;
        mc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            GameManager.isPlaying = false;
            Instantiate(finishPrefab);
        }
    }
}
