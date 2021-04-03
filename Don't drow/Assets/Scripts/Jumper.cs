using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Jump");
    }
}
