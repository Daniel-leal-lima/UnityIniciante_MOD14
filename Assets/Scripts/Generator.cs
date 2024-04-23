using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject helixGOPrefab;
    [SerializeField] GameObject endingZoneGOPrefab;
    [SerializeField] int numberOfHelices;
    [SerializeField] float offset = 5f;
    [SerializeField] bool test;
    Dictionary<int, GameObject> generatedObjects = new Dictionary<int, GameObject>();
    private void Start()
    {
        float playerY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        Vector3 t = new Vector3(transform.position.x, playerY, transform.position.z); 
        transform.position = t - (Vector3.up * offset);
        GenerateLevel();
    }

    private void Update()
    {
        if (test)
        {
            for (int i = 0; i < generatedObjects.Count; i++)
            {
                if(generatedObjects.TryGetValue(i, out GameObject value))
                {
                    value.transform.localPosition = Vector3.zero - (Vector3.up * offset * i);
                }
            }
        }
    }

    void GenerateLevel()
    {
        //generatedObjects = new GameObject[numberOfHelices];
        
        for (int i = 0; i < numberOfHelices; i++)
        {
            Vector3 pos = Vector3.zero - (Vector3.up * offset * i);
            if (i == numberOfHelices - 1)
            {
                GameObject instance = Instantiate(endingZoneGOPrefab,Vector3.zero,Quaternion.identity,transform);
                instance.transform.localPosition = pos;
                generatedObjects.Add(i, instance);
                break;
            }
            else
            {
                Quaternion rot = Quaternion.Euler(Vector3.up * Random.Range(0, 360));
                GameObject instance = Instantiate(helixGOPrefab, Vector3.zero, rot, transform);
                instance.transform.localPosition = pos;
                generatedObjects.Add(i, instance);
            }
        }
    }
}
