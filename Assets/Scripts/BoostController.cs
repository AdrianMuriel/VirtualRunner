using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostController : MonoBehaviour
{
    public PlayerMovement pm;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Active", true);
        }
    }


    public void Desactivate() => anim.SetBool("Active", false);
    public void Jump() => pm.Jump(30f);
}
