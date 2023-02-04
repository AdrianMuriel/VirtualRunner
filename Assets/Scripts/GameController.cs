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
            Debug.Log("Las vidas del jugador son " + playerLifes.life);
            yield return new WaitForSeconds(1.0f);
        }
        Debug.Log("Las vidas del jugador han llegado a 0.");
        SceneManager.LoadScene("GameOverScene");
    }

}
