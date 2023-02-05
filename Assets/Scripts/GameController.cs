using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerLife playerLifes;

    private IEnumerator coroutine;

    void Start()
    {
        coroutine = WaitAndPrint();
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndPrint()
    {
        while (playerLifes.life > 0)
        {
            yield return new WaitForSeconds(1.0f);
        }
        SceneManager.LoadScene("GameOverScene");
    }

}
