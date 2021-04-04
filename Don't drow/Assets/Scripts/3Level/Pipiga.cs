using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipiga : MagicDiogen
{
    public GameObject hat;
    public GameObject crown;
    public Diologue getCrown;
    public Diologue whyAreYouCame;
    public BoxCollider2D bx;
    public GameObject bottleOfUrine;
    public override void Update()
    {
        if (Input.GetKey(KeyCode.E) && isUsable && !isTalking)
        {
            Debug.Log(1);
            isTalking = true;
            if (!firstDialog)
            {
                Debug.Log(2);
                dm.StartDiologue(startDiologue);
                firstDialog = true;
            }
            else
            {
                if (hat.activeSelf)
                {
                    dm.StartDiologue(constantDiologue);
                    hat.SetActive(false);
                    bx.enabled = false;
                }
                else if (crown.activeSelf)
                {
                    dm.StartDiologue(getCrown);
                    crown.SetActive(false);
                    bx.enabled = false;
                    bottleOfUrine.SetActive(true);
                }
                else
                    dm.StartDiologue(whyAreYouCame);
            }
        }
    }
}
