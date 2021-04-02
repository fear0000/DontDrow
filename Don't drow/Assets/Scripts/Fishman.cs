using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishman : MonoBehaviour
{
    [SerializeField] private Animator bubbleAnim;
    [SerializeField] private Animator characterAnim;

    public void MakeBubble()
    {
        characterAnim.SetTrigger("MakeBubble");
        bubbleAnim.SetTrigger("MakeBubble");
    }
}
