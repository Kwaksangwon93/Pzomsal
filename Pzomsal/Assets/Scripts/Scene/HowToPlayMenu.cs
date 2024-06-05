using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    public GameObject HowToPlay;

    public void HowToPlayBtn()
    {
        HowToPlay.SetActive(true);
    }

    public void ComeBackHomeBtn()
    {
        HowToPlay.SetActive(false);
    }
}
