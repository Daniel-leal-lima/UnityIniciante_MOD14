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


        //MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; i++)
        {

            combine[i].mesh = meshFilters[i].sharedMesh;
            Matrix4x4 parentTransform = transform.worldToLocalMatrix;
            combine[i].transform = parentTransform * meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine, true, true);

        combinedMesh.Optimize();

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
        if (ball != null && !ball.IsBouncing()) ball.AddStreak();
        //if (_triggerDetected)
        //{
        //    if (rb.velocity.y < 0)
        //    {
        //        _currentStreak++;
        //    }
        //    _triggerDetected = false;
        //}
    }
}
