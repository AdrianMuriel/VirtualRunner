using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] public int life;
    [SerializeField] private Image[] lifeIcons;

    void Update()
    {
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

    public void DecrementLife()
    {
        life--;
    }
}
