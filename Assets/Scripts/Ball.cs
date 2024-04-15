using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float forceY;
    [SerializeField] int _currentStreak;
    bool _bouncing;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).point.y < transform.position.y)
        {
            rb.velocity = new Vector3(0, forceY);
            _bouncing = true;
        }
    }

    public void ResetStreak()
    {
        _currentStreak = 0;
    }

    public bool IsBouncing()
    {
        return _bouncing;
    }

    public void StopBouncing()
    {
        _bouncing = false;
    }

    public void AddStreak()
    {
        _currentStreak++;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (Vector3.Distance(transform.position, other.bounds.center) < 0.01f)
    //    {
    //        _triggerDetected = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (_triggerDetected)
    //    {
    //        if (rb.velocity.y < 0)
    //        {
    //            _currentStreak++;
    //        }
    //        _triggerDetected = false;
    //    }
    //}


}
