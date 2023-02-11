using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public PlayerLife playerLifes;
    [SerializeField] private float shotTime = 2f;
    private Animator anim;
    private Rigidbody2D rb;
    Vector3 localScale;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
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
            yield return new WaitForSeconds(shotTime);
            anim.SetBool("Shoot", true);
            yield return new WaitForSeconds(0.0125f);
            anim.SetBool("Shoot", false);
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position - new Vector3(1.25f, 0f, 0f), Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(-firePoint.right * bulletSpeed, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerFeet")
        {
            anim.SetBool("Hitted", true);
        }

    }

    void destroyEnemy() => Destroy(this.gameObject);
}

