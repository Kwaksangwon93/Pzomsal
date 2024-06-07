using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToFirst : MonoBehaviour
{
    public void GoToFirstScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
