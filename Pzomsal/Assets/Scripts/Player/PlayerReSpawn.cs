using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReSpawn : MonoBehaviour
{

    private List<string[]> Quizs;


    private void Awake()
    {
        Quizs = new List<string[]>();

    }


    private void OnEnable()
    {
        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        Time.timeScale = 0.0f;



    }

}
