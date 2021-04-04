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
        hatOnPanel.SetActive(false);
    }
}
