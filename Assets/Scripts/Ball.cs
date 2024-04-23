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

            if (_currentStreak >= 2)
            {
                if(collision.transform.parent.TryGetComponent(out DestroyHandler script))
                {
                    StartCoroutine(script.Destroy());
                }
            }
            ResetStreak();
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

}
