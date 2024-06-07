using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    public GameObject[] pages;
    public Button prevBtn;
    public Button nextBtn;
    public Button skipBtn;

    private int currentPage = 0;

    void Start()
    {
        UpdatePage();
    }

    void UpdatePage()
    {
        foreach (var page in pages)
        {
            page.SetActive(false);
        }

        if (currentPage >= 0 && currentPage < pages.Length)
        {
            pages[currentPage].SetActive(true);
        }
    }

    public void OnPrevButtonClick()
    {
        if (currentPage == 0)
        {
            SceneManager.LoadScene("StartScene");
        }
        else
        {
            currentPage--;
            UpdatePage();
        }
    }

    public void OnNextButtonClick()
    {
        if (currentPage == pages.Length - 1)
        {
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            currentPage++;
            UpdatePage();
        }
    }

    public void OnSkipButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
