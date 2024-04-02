using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnable : MonoBehaviour
{
    [SerializeField] float force;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(Vector3.up, (touch.deltaPosition.x * force) * -1);
            }
        }
    }

    //void OnGUI()
    //{
    //    force = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), force, 0.0F, 1f);
    //    GUI.Label(new Rect(25, 25, 100, 30),force.ToString());
    //}
}
