using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void LoadGame() => SceneManager.LoadScene("GameScene");

    public void ExitGame() => Application.Quit();
}
