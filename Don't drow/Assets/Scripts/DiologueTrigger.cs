using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologueTrigger : MonoBehaviour
{
    public Diologue diologue;

    public virtual void TriggerDiologue()
    {
        FindObjectOfType<DialogManager>().StartDiologue(diologue);
    }
}
