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
    public GameObject bred;
    public GameObject juice;
    public Animator diologAnim;
    public BoxCollider2D bx;
    public static bool isBred;
    public static bool isJuice;

    public Diologue dialog;
    private void Start()
    {
        isBred = false;
        isJuice = false;
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
            if (PlayerPrefs.GetString("bred") != "on" && PlayerPrefs.GetString("juice") != "on")
            {
                StartCoroutine(FirstEnding());
            }
            if (PlayerPrefs.GetString("bred") == "on")
            {
                bred.SetActive(true);
                PlayerPrefs.SetString("bred", "off");
                isBred = true;
                if(PlayerPrefs.GetString("juice") != "on")
                {
                    StartCoroutine(FirstEnding());
                }
            }
            else if(PlayerPrefs.GetString("juice") == "on")
            {
                juice.SetActive(true);
                PlayerPrefs.SetString("juice", "off");
                isJuice = true;
                if (PlayerPrefs.GetString("bred") != "on")
                {
                    StartCoroutine(FirstEnding());
                }
            }
            bx.enabled = false;
            isUsable = false;
            eAnim.SetTrigger("Close");
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
    private IEnumerator FirstEnding()
    {
        characterAnim.SetTrigger("Off");
        yield return new WaitForSeconds(5f);
        characterAnim.SetTrigger("FirstEnding");
        panelAnim.SetTrigger("FirstEnding");
    }
}
