using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float timeUntilRotate;
    private bool isOnce = true;
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
        if (isOnce)
        {
            StartCoroutine(RotateSaw());
            isOnce = false;
        }
    }

    IEnumerator RotateSaw()
    {
        yield return new WaitForSeconds(timeUntilRotate);
        speed = -speed;
        StartCoroutine(RotateSaw());
        
    }
}
