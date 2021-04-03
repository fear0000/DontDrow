using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Crown") == 1)
        {
            gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}
