using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject soundMenu;

    [HideInInspector]
    public bool canOpen = true;

    public void OnMenuButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            ToggleMenu();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canOpen = !toggle;
    }

    void ToggleMenu()
    {
        if (menuPanel != null)
        {
            bool isActive = menuPanel.activeSelf;

            menuPanel.SetActive(!isActive);
        }
    }

    public void SoundMenu()
    {
        soundMenu.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Continue()
    {
        menuPanel.SetActive(false);
        ToggleCursor();
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void GoBack()
    {
        soundMenu.SetActive(false);
        menuPanel.SetActive(true);
    }
}