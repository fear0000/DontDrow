using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoadMoving : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        rb.velocity = Vector3.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.velocity = Vector3.zero;
        anim.SetTrigger("isStoped");
    }
    public void OnKill()
    {
        var playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector3.down * 4.5f;
    }
}
