using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keeper : DiologueTrigger
{
    public Animator anim;
    public bool isOnce = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box" && isOnce)
        {
            anim.SetTrigger("Awake");
            TriggerDiologue();
            isOnce = !isOnce;
        }
            
    }
}
