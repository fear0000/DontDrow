using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLoading : MonoBehaviour
{
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject sock;
    [SerializeField] private GameObject hat;
    [SerializeField] private GameObject crown;
    [SerializeField] private GameObject flash;
    [SerializeField] private GameObject bottle;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Book") == 1)
        {
            book.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Sock") == 1)
        {
            sock.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Hat") == 1)
        {
            hat.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Crown") == 1)
        {
            crown.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Book") == 1)
        {
            flash.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Bottle") == 1)
        {
            bottle.SetActive(true);
        }
    }
}
