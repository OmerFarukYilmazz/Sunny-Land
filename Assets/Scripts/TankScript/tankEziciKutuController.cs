using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEziciKutuController : MonoBehaviour
{
    KutuControl kutuControl;


    private void Awake()
    {
        kutuControl = Object.FindObjectOfType<KutuControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            kutuControl.JumpPlayer();
        }
    }
}
