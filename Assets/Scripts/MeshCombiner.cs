using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner
{
    public static Mesh Combine(MeshFilter[] meshFilters, Transform t, bool hideObjectsOnExit = true)
    {
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        for (int i = 0; i < meshFilters.Length; i++)
        {

            combine[i].mesh = meshFilters[i].sharedMesh;
            Matrix4x4 parentTransform = t.worldToLocalMatrix;
            combine[i].transform = parentTransform * meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(!hideObjectsOnExit);
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.CombineMeshes(combine, true, true);

        combinedMesh.Optimize();

        return combinedMesh;
    }
}
