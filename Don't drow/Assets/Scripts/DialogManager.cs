using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Animator dialogueAnim;
    public event Action EndDialogue;
    public GameObject key;
    public Transform keyKeeper;
    private bool isRooted;
    //Исправить говно
    public Animator fishAnim;
    public Animator characterAnim;
    public Rigidbody2D character;
    //
    private Queue<string> sentences;
    private void Start()
    {
        sentences = new Queue<string>();
        isRooted = true;
    }

    public void StartDiologue(Diologue diologue)
    {
        dialogueAnim.SetTrigger("Open");
        nameText.text = diologue.name;

        sentences.Clear();

        foreach(string sentence in diologue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            if(sentences.Count == 0)
                {
                    EndDiologue();
                    return;
                }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char symbol in sentence.ToCharArray())
        {
            dialogueText.text += symbol;
            yield return new WaitForSeconds(0.03f);
        }
    }
    public void EndDiologue()
    {
        dialogueAnim.SetTrigger("Close");
        if(characterAnim != null)
        {
            characterAnim.enabled = true;
            character.constraints = RigidbodyConstraints2D.None;
            character.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (isRooted && characterAnim != null)
        {
            fishAnim.SetTrigger("MakeBubble");
            characterAnim.SetTrigger("MakeBubble");
            isRooted = !isRooted;
        }
        if(key != null)
        {
            Instantiate(key, keyKeeper);
        }
        EndDialogue?.Invoke();
    }
}
