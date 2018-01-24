using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScore : MonoBehaviour 
{
    [SerializeField] private ControllerDetection contDetect;
    [SerializeField] private int totalPickups = 0;
    [SerializeField] private int messesPickedUp = 0;
    private int[] scoreElements = { 0, 0 };
    [SerializeField] private PickupCounter pickupCounters;

    [SerializeField] private GameObject gameOverText;
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject playAgainButton;
    [SerializeField] private GameObject quitButton;

    private void Awake()
    {
        pickupCounters = GameObject.FindGameObjectWithTag("Pickup Counter").GetComponent<PickupCounter>();
        contDetect = GetComponentInChildren<ControllerDetection>();
        gameOverText.SetActive(false);
        winText.SetActive(false);
        loseText.SetActive(false);
        playAgainButton.SetActive(false);
        quitButton.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(messesPickedUp == totalPickups)
            GameOver();
    }

    public void SetScore()
    {
        totalPickups = pickupCounters.GetActivePickups();
        messesPickedUp = pickupCounters.GetPickedUpCount();
    }

    public int[] GetScore()
    {
        scoreElements[0] = messesPickedUp;
        scoreElements[1] = totalPickups;
        return scoreElements;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
        

        if (messesPickedUp == totalPickups)
        {            
            
            winText.SetActive(true);
            playAgainButton.SetActive(true);
            quitButton.SetActive(true);

            SetWinLoseGuiState();
        }
        else
        {
            loseText.SetActive(true);
            playAgainButton.SetActive(true);
            quitButton.SetActive(true);

            SetWinLoseGuiState();
        }

    }

    void SetWinLoseGuiState()
    {
        if (contDetect.GetController() > 0)
        {
            EventSystem.current.firstSelectedGameObject = GameObject.FindGameObjectWithTag("PlayAgainButton");

            if (EventSystem.current.currentSelectedGameObject == null)
                EventSystem.current.SetSelectedGameObject(GameObject.FindGameObjectWithTag("PlayAgainButton"));
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
