using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Animator eAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Transform playerTransform;
    private bool isUsable;
    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        playerTransform = player.GetComponent<Transform>();
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
        if(Input.GetKey(KeyCode.E) && isUsable)
        {
            CatchItem();
        }
    }

    public virtual void CatchItem()
    {
        if(gameObject.tag == "crown")
        {
            PlayerPrefs.SetString("crown", "on");
        }
        if (gameObject.tag == "hat")
        {
            PlayerPrefs.SetString("hat", "on");
        }
        if (gameObject.tag == "bred")
        {
            PlayerPrefs.SetString("bred", "on");
        }
        if (gameObject.tag == "juice")
        {
            PlayerPrefs.SetString("juice", "on");
        }
        playerAnim.SetTrigger("Catch");
        StartCoroutine(GoToPanel());
    }

    IEnumerator GoToPanel()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
