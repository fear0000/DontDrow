using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private Button button;
    private int countOfBox;
    private void Start()
    {
        button.Change += OnChange;
        countOfBox = 2;
    }
    private void SpawnBox()
    {
        Instantiate(box, transform.position, Quaternion.identity);
    }
    private void OnChange(object sender, ChangeEventArgs e)
    {
        if (e.isPressed && countOfBox > 0)
        {
            SpawnBox();
            countOfBox--;
        }
    }
    private void OnDestroy()
    {
        button.Change -= OnChange;
    }
}
