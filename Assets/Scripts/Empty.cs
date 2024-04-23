using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    Ball ball;

    void Start()
    {
        Helix[] allHelices = GetComponentsInChildren<Helix>();
        List<MeshFilter> meshFilters = new List<MeshFilter>();

        foreach (var helix in allHelices)
        {
            if (helix.isBreakable)
            {
                meshFilters.Add(helix.GetComponent<MeshFilter>());
            }
        }

        Mesh combinedMesh = MeshCombiner.Combine(meshFilters.ToArray(), transform);

        MeshCollider mc = gameObject.AddComponent<MeshCollider>();
        mc.sharedMesh = combinedMesh;
        mc.convex = true;
        mc.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out ball);
        if (ball != null)
        {
            ball.StopBouncing();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (ball != null && !ball.IsBouncing())
        {
            ball.AddStreak();
        }
    }
}
