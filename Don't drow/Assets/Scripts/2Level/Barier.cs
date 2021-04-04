using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Sprite[] onOffBarier;
    [SerializeField] private Sprite[] onOffButton;
    private void Start()
    {
        button.Change += OnChange;
    }

    private void OnChange(object sender, ChangeEventArgs e)
    {
        foreach (var item in gameObjects)
        {
            if (item.tag == "Barier")
            {
                if (item.GetComponent<BoxCollider2D>().enabled)
                {
                    item.GetComponent<SpriteRenderer>().sprite = onOffBarier[1];
                    item.GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    item.GetComponent<SpriteRenderer>().sprite = onOffBarier[0];
                    item.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            if (item.tag == "Button")
            {
                if (item.activeSelf)
                {
                    item.SetActive(false);
                    item.GetComponent<BoxCollider2D>().enabled = false;
                }
                else
                {
                    item.SetActive(true);
                    item.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }
    private void OnDestroy()
    {
        button.Change -= OnChange;
    }
}
