using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("isFloatUp");
        var playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector3.down * 1.7f;
    }
}
