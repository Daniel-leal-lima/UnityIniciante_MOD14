using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] AnimController anim;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform ballTransform;
    [SerializeField] float distanceY;
    //bool isOnGround;


    private void FixedUpdate()
    {
        if (Physics.Raycast(ballTransform.position, Vector3.down, out RaycastHit hit, distanceY))
        {
            if (hit.collider.TryGetComponent(out Helix helix))
            {
                if (!helix.isBreakable && ballTransform.position == transform.position)
                {
                    rb.isKinematic = true;
                    anim.Bounce();
                }
            }
        }
    }

    private void Update()
    {
        if (ballTransform.position == transform.position)
        {
            rb.velocity = new(0, -9.8f, 0);
            rb.isKinematic = false;
        }

    }
}
