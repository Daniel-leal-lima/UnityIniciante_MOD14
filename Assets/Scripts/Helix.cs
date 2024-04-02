using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Helix : MonoBehaviour
{
    public bool isBreakable;

    private void OnValidate()
    {
        GetComponent<MeshRenderer>().enabled = !isBreakable;
        MeshCollider mc = GetComponent<MeshCollider>();
        mc.convex = true;
        mc.isTrigger = isBreakable;
    }
}
