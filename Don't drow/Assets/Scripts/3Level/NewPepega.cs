using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPepega : MonoBehaviour
{
    [SerializeField] public DialogManager dm;
    [SerializeField] private Animator eAnim;
    [SerializeField] public Diologue startDiologue;
    [SerializeField] public Diologue hatDiologue;
    public Diologue getCrown;
    public Diologue whyAreYouCame;
    public GameObject bottleOfUrine;
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
    public void Update()
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
                if (PlayerPrefs.GetString("hat") == "on")
                {
                    dm.StartDiologue(hatDiologue);
                    PlayerPrefs.SetString("hat", "off");
                }
                else if (PlayerPrefs.GetString("crown") == "on")
                {
                    dm.StartDiologue(getCrown);
                    PlayerPrefs.SetString("crown", "off");
                    bottleOfUrine.SetActive(true);
                }
                else
                    dm.StartDiologue(whyAreYouCame);
            }
        }
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
}
