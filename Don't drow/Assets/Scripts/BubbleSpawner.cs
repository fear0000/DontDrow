﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] private bool isChanging;
    private bool isActive;
    private void Start()
    {
        if (isChanging)
        {
            isActive = false;
            StartCoroutine(Reload());
        }
    }
    private void Update()
    {
        if(!isChanging)
        {
            Bubbles();
        }
        if (isActive)
        {
            Bubbles();
        }
    }
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(5f);
        isActive = !isActive;
        StartCoroutine(Shot());
    }
    private IEnumerator Shot()
    {
        yield return new WaitForSeconds(1.5f);
        isActive = !isActive;
        StartCoroutine(Reload());
    }
    private void Bubbles()
    {
        Debug.DrawRay(gameObject.transform.position, transform.up * 25f, Color.red);
        if (Physics2D.RaycastAll(transform.position, Vector2.up) != null)
        {
            var boxes = Physics2D.RaycastAll(transform.position, Vector2.up);
            foreach (var box in boxes)
            {
                if (box.collider.gameObject.tag == "Box")
                {
                    box.rigidbody.AddForce(Vector2.up * 125);
                }
            }
        }
    }
}
