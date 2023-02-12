using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameController gc;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            gc.score++;
            gc.scoreAux++;
            anim.SetBool("Collected", true);
        }
    }

    public void destroyFruit() => Destroy(this.gameObject);
}
