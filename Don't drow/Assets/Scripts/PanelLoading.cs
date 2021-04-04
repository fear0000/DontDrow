using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoading : MonoBehaviour
{
    [SerializeField] private GameObject crown;
    [SerializeField] private GameObject hat;
    [SerializeField] private GameObject juice;
    [SerializeField] private GameObject bred;

    private void Update()
    {
        if (PlayerPrefs.GetString("crown") == "on")
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
        if (PlayerPrefs.GetString("bred") == "on")
        {
            bred.SetActive(true);
        }
        else
        {
            bred.SetActive(false);
        }
        if (PlayerPrefs.GetString("juice") == "on")
        {
            juice.SetActive(true);
        }
        else
        {
            juice.SetActive(false);
        }
        if (PlayerPrefs.GetString("hat") == "on")
        {
            hat.SetActive(true);
        }
        else
        {
            hat.SetActive(false);
        }
    }
}
