using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void Start()
    {
        if (this.gameObject.tag == "Player")
        {
            anim = GetComponent<Animator>();
        }
    }
    public void MainMenu() => SceneManager.LoadScene("MainMenuScene");
    public void LoadGame() => SceneManager.LoadScene("GameScene");
    public void RestartGame() => anim.SetBool("Restart", true);

    public void ExitGame() => Application.Quit();
}
