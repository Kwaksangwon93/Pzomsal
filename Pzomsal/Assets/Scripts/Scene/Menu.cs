using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject menuStandPanel;

    [HideInInspector]
    public bool canOpen = true;
    public Action menu;

    public void OnMenuButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            ToggleMenuStand();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canOpen = !toggle;
    }

    void ToggleMenuStand()
    {
        if (menuStandPanel != null)
        {
            bool isActive = menuStandPanel.activeSelf;

            menuStandPanel.SetActive(!isActive);
        }
    }
}