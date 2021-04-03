using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokablePlatform : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("isBroken", true);
            StartCoroutine(BrokePlatform());
            StartCoroutine(EneblePlatform());
        }
    }

    IEnumerator BrokePlatform()
    {
        anim.SetBool("isBroken", true);
        yield return new WaitForSeconds(2f);
    }
    IEnumerator EneblePlatform()
    {
        yield return new WaitForSeconds(4f);
        anim.SetBool("isBroken", false);
    }
}
