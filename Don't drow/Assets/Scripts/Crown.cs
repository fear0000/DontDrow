using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : Item
{
    public GameObject hatOnPanel;
    public GameObject hat;
    public GameObject hatSpawnPoint;
    public string oppositeHat;
    public override void CatchItem()
    {
        base.CatchItem();
        PlayerPrefs.SetInt(oppositeHat, 0);
        hatOnPanel.SetActive(false);
        if (!hat.activeSelf)
        {
            Instantiate(hat, hatSpawnPoint.transform);
        }
        
    }
}
