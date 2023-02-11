using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemiesController : MonoBehaviour
{
    public PlayerLife playerLifes;
    [SerializeField] private float turnTime = 2f;
    private Animator anim;
    private Rigidbody2D rb;
    Vector3 localScale;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        StartCoroutine(enemyCorutine());
    }

    private IEnumerator enemyCorutine()
    {
        while (true)
        {
            rb.velocity = new Vector2(-5f, 0f);
            yield return new WaitForSeconds(turnTime);
            localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            rb.velocity = new Vector2(5f, 0f);
            yield return new WaitForSeconds(turnTime);
            localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerFeet")
        {
            other.gameObject.transform.up += Vector3.up*5f;
            anim.SetBool("Hitted", true);
        }

    }

    void destroyEnemy() => Destroy(this.gameObject);
}
