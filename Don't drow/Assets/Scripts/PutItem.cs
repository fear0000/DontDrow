using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutItem : MonoBehaviour
{
    public Animator eAnim;
    public bool isUsable;
    public Animator characterAnim;
    public Animator panelAnim;
    public DialogManager dm;
    public GameObject item;
    public Animator diologAnim;


    public Diologue dialog;
    private void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Count"));
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
        if (isUsable && Input.GetKey(KeyCode.E))
        {
            item.transform.SetParent(transform);
            eAnim.SetTrigger("Close");
            Put();
        }
    }

    private void Put()
    {
        PlayerPrefs.SetInt("I", PlayerPrefs.GetInt("I") + 1);
        if(PlayerPrefs.GetInt("Count") == PlayerPrefs.GetInt("I") && PlayerPrefs.GetInt("Count") == 1)
        {
            StartCoroutine(FirstEnding());
        }
        else if(PlayerPrefs.GetInt("Count") == PlayerPrefs.GetInt("I") && PlayerPrefs.GetInt("Count") == 2)
        {
            dm.StartDiologue(dialog);
        }
    }
    public void SecondEnding()
    {
        diologAnim.SetTrigger("Close");
        panelAnim.SetTrigger("SecondEnding");
    }
    public void StartFirstCoroutine()
    {
        diologAnim.SetTrigger("Close");
        StartCoroutine(FirstEnding());
    }
    IEnumerator FirstEnding()
    {
        characterAnim.SetTrigger("Off");
        yield return new WaitForSeconds(5f);
        characterAnim.SetTrigger("FirstEnding");
        panelAnim.SetTrigger("FirstEnding");
    }
}
