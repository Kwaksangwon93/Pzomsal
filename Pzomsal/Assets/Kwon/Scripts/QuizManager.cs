using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.WebRequestMethods;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI board;
    public Button button0;
    public Button button1;
    public Button button2;
    public Button button3;

    public TextMeshProUGUI timeText;
    private float time;

    public QuizData[] quizDatas;
    private int i;
    private int flag;

    private void Start()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        time -= Time.unscaledDeltaTime;
        
        timeText.text = ((int)time).ToString();

        if(time <= 0f)
        {
            TimeOver();
        }
    }

    

    private void OnEnable()
    {
        ToggleCursor();
        Time.timeScale = 0;
        time = 21f;

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
        Time.timeScale = 1.0f;
        ToggleCursor();
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Heal(100);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Eat(100);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Drink(100);
        this.gameObject.SetActive(false);
    }

    public void Incorrect()
    { 
        Time.timeScale = 1.0f;
        ToggleCursor();
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Heal(50);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Eat(50);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Drink(50);
        this.gameObject.SetActive(false);
    }

    private void TimeOver()
    {
        Time.timeScale = 1.0f;
        ToggleCursor();
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Heal(15);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Eat(50);
        CharacterManager.Instance.Player.GetComponent<PlayerCondition>().Drink(50);
        this .gameObject.SetActive(false);
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        CharacterManager.Instance.Player.GetComponent<PlayerController>().canLook = !toggle;
    }
}
