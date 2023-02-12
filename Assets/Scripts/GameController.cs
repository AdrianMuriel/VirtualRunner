using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerLife playerLifes;
    public int score = 0;
    public int scoreAux = 0;
    [SerializeField] private Text scoreTxt;

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
            scoreTxt.text = score.ToString();
            yield return new WaitForSeconds(1.0f);
            scoreTxt.text = score.ToString();
            if (scoreAux == 5)
            {
                scoreAux = 0;
                if (playerLifes.life < 3)
                {
                    playerLifes.life++;
                }
            }

        }
        SceneManager.LoadScene("GameOverScene");
    }

}
