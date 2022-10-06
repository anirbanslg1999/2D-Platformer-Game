using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {

            //PlayerController playerController = (PlayerController)collision.gameObject.GetComponent<PlayerController>();
            playerController.GotKey();
            AudioManager.Instance.PlayEffectSound(SoundTypes.Collectable);
            //GetComponent<BoxCollider2D>().isTrigger = true;
            animator.SetBool("hasPickedUp", true);
            Destroy(gameObject, 0.5f);
            //collision.gameObject.GetComponent<PlayerController>() != null
        }
    }
}
