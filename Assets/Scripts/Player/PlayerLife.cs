using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] public int life;
    [SerializeField] private Image[] lifeIcons;

    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            life--;
            transform.position = new Vector2(respawnPoint.position.x, Camera.main.transform.position.y + Camera.main.orthographicSize);
        }
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < life)
            {
                lifeIcons[i].enabled = true;
            }
            else
            {
                lifeIcons[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            DecrementLife();
        }

    }

    public void DecrementLife()
    {
        life--;
    }
}
