using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.WebRequestMethods;

public class QuizManager : MonoBehaviour
{
    
    public QuizManager quizManager;

    public TextMeshProUGUI board;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;

    public QuizData[] quizDatas;
    private int i;

    private void Awake()
    {
        quizManager = this;
    }


    private void OnEnable()
    {
        Time.timeScale = 0;

        i = Random.Range(0, quizDatas.Length);
        int flag = Random.Range(0, 4);

        string text = quizDatas[i].Question.Replace("\\n", "\n");
        board.text = text;

        switch (flag)
        {
            case 0:
                button0.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Answer;

                button1.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_1;
                button2.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_2;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_3;
                break;
            
            case 1:
                button1.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Answer;

                button0.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_1;
                button2.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_2;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_3;
                break;
            
            case 2:
                button2.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Answer;

                button0.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_1;
                button1.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_2;
                button3.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_3;
                break;
            
            case 3:
                button3.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Answer;

                button0.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_1;
                button1.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_2;
                button2.GetComponentInChildren<TextMeshProUGUI>().text = quizDatas[i].Wrong_3;
                break;
        }
    }


    public void CheckButton0()
    {
        if (button0.GetComponentInChildren<TextMeshProUGUI>().text == quizDatas[i].Answer)
        {
            Correct();
        }

        else
        {
            Incorrect();
        }

    }

    public void CheckButton1()
    {
        if (button1.GetComponentInChildren<TextMeshProUGUI>().text == quizDatas[i].Answer)
        {
            Correct();
        }

        else
        {
            Incorrect();
        }
    }

    public void CheckButton2()
    {
        if (button2.GetComponentInChildren<TextMeshProUGUI>().text == quizDatas[i].Answer)
        {
            Correct();
        }

        else
        {
            Incorrect();
        }
    }

    public void CheckButton3()
    {
        if (button3.GetComponentInChildren<TextMeshProUGUI>().text == quizDatas[i].Answer) 
        {
            Correct();
        }
        
        else
        {
            Incorrect();
        }
    }

    public void Correct()
    {
        Debug.Log("정답");

        /*
         
        플레이어 풀피 구현

        */

        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    public void Incorrect()
    {
        Debug.Log("오답");

        /*

       플레이어 반피 구현

       */

        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }
}
