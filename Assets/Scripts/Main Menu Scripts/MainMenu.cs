using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;
    [SerializeField] private ControllerDetection contDect;
    [SerializeField] private GameObject currentButton;
    private StandaloneInputModule standAloneInputMod;
    private StandaloneInputModule startInputMod;

    private void Start()
    {
        contDect = GetComponent<ControllerDetection>();
        standAloneInputMod = GameObject.FindGameObjectWithTag("MainMenuEventSys").GetComponent<StandaloneInputModule>();
        startInputMod = standAloneInputMod;
        currentButton = EventSystem.current.firstSelectedGameObject;
    }

    private void FixedUpdate()
    {
        if (contDect.GetController() > 0)
        {
            standAloneInputMod.verticalAxis = "MenuMoveController";
            standAloneInputMod.submitButton = "MenuSubmitController";
            standAloneInputMod.cancelButton = "MenuCancelController";

            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(currentButton);
        }
        else
        {
            standAloneInputMod.verticalAxis = startInputMod.verticalAxis;
            standAloneInputMod.cancelButton = startInputMod.cancelButton;
            standAloneInputMod.submitButton = startInputMod.submitButton;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}
