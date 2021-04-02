using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioSorce;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSorce = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSorce.Play();
        anim.SetTrigger("isDrow");
        var playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector3.down * 1.7f;
    }
}
