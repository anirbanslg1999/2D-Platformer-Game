using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.GotKey();
            //GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetBool("hasPickedUp", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
