using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Animator doorAnim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        doorAnim = GameObject.FindGameObjectWithTag("Door").GetComponent<Animator>();
        if(collision.gameObject.tag == "Player")
        {
            doorAnim.SetTrigger("Open");
            Destroy(gameObject);
        }
        
    }
}
