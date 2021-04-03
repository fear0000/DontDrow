using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishman : MonoBehaviour
{
    [SerializeField] private Animator bubbleAnim;
    [SerializeField] private Animator characterAnim;
    public DiologueTrigger diologueTrigger;
    private bool isUsable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            isUsable = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            isUsable = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && isUsable)
        {
            diologueTrigger.TriggerDiologue();
        }
    }
    public void MakeBubble()
    {
        characterAnim.SetTrigger("MakeBubble");
        bubbleAnim.SetTrigger("MakeBubble");
    }
}
