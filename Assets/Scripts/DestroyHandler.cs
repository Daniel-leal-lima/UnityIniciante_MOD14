using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform[] childs;
    void Start()
    {
        childs = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i);
        }
    }
    public IEnumerator Destroy()
    {
        foreach (var item in childs)
        {
            Rigidbody rb =item.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(-item.forward, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
