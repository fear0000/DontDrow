using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiologueTrigger : MonoBehaviour
{
    public Diologue diologue;

    public void TriggerDiologue()
    {
        Debug.Log("jopa");
        FindObjectOfType<DialogManager>().StartDiologue(diologue);
    }
}
