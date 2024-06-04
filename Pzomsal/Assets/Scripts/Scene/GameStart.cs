using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Coroutine coroutine;

    public void GameStartBtn()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainScene");
        StopCoroutine(LoadMainScene());
    }
}
