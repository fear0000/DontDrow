using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Fishman : MonoBehaviour
{
    [SerializeField] private DialogManager dm;
    [SerializeField] private Diologue startDiologue;
    [SerializeField] private Diologue constantDiologue;
    [SerializeField] private Animator bubbleAnim;
    [SerializeField] private Animator characterAnim;
    [SerializeField] private Animator eAnim;
    private bool isUsable;
    private bool firstDialog;
    private bool isTalking;
    private void Start()
    {
        dm.EndDialogue += OnEndDialogue;
        firstDialog = false;
        isTalking = false;
    }

    private void OnEndDialogue()
    {
        isTalking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isUsable = true;
            eAnim.SetTrigger("Open");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isUsable = false;
            eAnim.SetTrigger("Close");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && isUsable && !isTalking)
        {
            isTalking = true;
            if (!firstDialog)
            {
                dm.StartDiologue(startDiologue);
                firstDialog = true;
            }
            else
            {
                dm.StartDiologue(constantDiologue);
            }
        }
    }
    public void MakeBubble()
    {
        characterAnim.SetTrigger("MakeBubble");
        bubbleAnim.SetTrigger("MakeBubble");
    }
}
