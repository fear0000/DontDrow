using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDiogen : MonoBehaviour
{
    [SerializeField] public DialogManager dm;
    [SerializeField] public Diologue startDiologue;
    [SerializeField] public Diologue constantDiologue;
    [SerializeField] public Diologue helpDiologue;
    [SerializeField] private Animator eAnim;
    public bool isUsable;
    public bool firstDialog;
    public bool isTalking;
    
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
    public virtual void Update()
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
