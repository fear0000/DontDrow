using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerScene : MonoBehaviour
{
    [SerializeField] private Animator animDark;
    [SerializeField] private BoadMoving bm;
    [SerializeField] Animator buttom;
    [SerializeField] Animator logo;
    private Animator anim;
    private AudioSource audioSorce;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSorce = gameObject.GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        bm.Move();
        logo.SetTrigger("Off");
        buttom.SetTrigger("Off");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NextScene")
        {
            animDark.SetTrigger("isDarken");
            StartCoroutine(NextScene());
        }
        else
        {
            audioSorce.Play();
            anim.SetTrigger("isDrow");
            var playerRb = gameObject.GetComponent<Rigidbody2D>();
            playerRb.velocity = Vector3.down * 1.7f;
        }
    }
    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    } 
}
