using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public PutItem putitem;
    private bool isEnding;
    // Start is called before the first frame update
    void Start()
    {
        isEnding = false;
    }

    void Update()
    {
        if (!isEnding)
        {
            if (PutItem.isBred && PutItem.isJuice)
            {
                putitem.dm.StartDiologue(putitem.dialog);
                isEnding = true;
            }
        }
    }
}
