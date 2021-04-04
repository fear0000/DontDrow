using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDiogen : MonoBehaviour
{
    [SerializeField] private DialogManager dm;
    [SerializeField] private Diologue startDiologue;
    [SerializeField] private Diologue constantDiologue;
    [SerializeField] private Diologue helpDiologue;
    [SerializeField] private Animator eAnim;
    [SerializeField] private Animator dioAnim;
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
}
