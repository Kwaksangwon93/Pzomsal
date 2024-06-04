using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.WebRequestMethods;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI board;
    public TextMeshProUGUI answer;
    public TextMeshProUGUI wrong_1;
    public TextMeshProUGUI wrong_2;
    public TextMeshProUGUI wrong_3;

    public QuizData[] quizDatas;

    private void OnEnable()
    {
        int i = Random.Range(0, quizDatas.Length);
        board.text = quizDatas[i].Question;
        answer.text = quizDatas[i].Answer;
        wrong_1.text = quizDatas[i].Wrong_1;
        wrong_2.text = quizDatas[i].Wrong_2;
        wrong_3.text = quizDatas[i].Wrong_3;
    }
}
