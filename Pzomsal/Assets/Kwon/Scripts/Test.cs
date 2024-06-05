using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject quiz;
    public float time;

    private void Awake()
    {
        time = 10f;
        quiz = GameObject.Find("Quiz");
    }


     void Update()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            time = 10f;
            quiz.SetActive(true);
        }
    }

}
