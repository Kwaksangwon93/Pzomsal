using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Data", menuName = "Scriptable Object/Quiz Data")]

public class QuizData : ScriptableObject
{
    [SerializeField]
    private string question;
    public string Question { get { return question; } }

    [SerializeField]
    private string answer;
    public string Answer { get { return answer; } }

    [SerializeField]
    private string wrong_1;
    public string Wrong_1 { get { return wrong_1; } }

    [SerializeField]
    private string wrong_2;
    public string Wrong_2 { get { return wrong_2; } }

    [SerializeField]
    private string wrong_3;
    public string Wrong_3 { get { return wrong_3; } }
}
