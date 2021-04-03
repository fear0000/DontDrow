using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Sprite[] onOffButton;
    private SpriteRenderer sr;
    public event EventHandler<ChangeEventArgs> Change;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sr.sprite = onOffButton[1];
        var changeEventArgs = new ChangeEventArgs { isPressed = true };
        Change?.Invoke(this, changeEventArgs);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = onOffButton[0];
        var changeEventArgs = new ChangeEventArgs { isPressed = false };
        Change?.Invoke(this, changeEventArgs);
    }
}
public class ChangeEventArgs : EventArgs
{
    public bool isPressed { get; set; }
}
