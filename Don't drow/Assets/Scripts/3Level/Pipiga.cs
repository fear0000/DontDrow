using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipiga : MagicDiogen
{
    public GameObject hat;
    public GameObject crown;
    public Diologue getCrown;
    public Diologue whyAreYouCame;
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
                    dm.StartDiologue(constantDiologue);
                else if (crown.activeSelf)
                    dm.StartDiologue(getCrown);
                else
                    dm.StartDiologue(whyAreYouCame);
            }
        }
    }
}
