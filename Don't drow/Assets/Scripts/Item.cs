using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Animator eAnim;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform panelTransform;
    [SerializeField] private GameObject itemOnPanel;

    public string nameOfItem;

    private bool isUsable;


    private void Awake()
    {
        if(PlayerPrefs.GetInt(nameOfItem) == 1)
        {
            Destroy(gameObject);
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

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && isUsable)
        {
            CatchItem();
        }
    }

    public virtual void CatchItem()
    {
        playerAnim.SetTrigger("Catch");
        gameObject.transform.SetParent(playerTransform);
        StartCoroutine(GoToPanel());
    }

    IEnumerator GoToPanel()
    {
        yield return new WaitForSeconds(1f);
        Save();
        itemOnPanel.SetActive(true);
        Destroy(gameObject);
    }

    public void Save()
    {
        PlayerPrefs.SetInt(nameOfItem, 1);
        PlayerPrefs.SetInt("Count", PlayerPrefs.GetInt("Count") + 1);
    }
}
