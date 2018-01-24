using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour 
{
    private BasicMessPickup basicMess;
    private ExplodingMessPickup explodingMess;
    private PlayerScore score;
    private ControllerDetection controllerDet;
    private Animator anim;
    [SerializeField] GameObject pickupTextController;
    [SerializeField] GameObject pickupTextKeyboard;
    [SerializeField] private Text scoreText;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        score = gameObject.GetComponent<PlayerScore>();
        controllerDet = Camera.main.GetComponent<ControllerDetection>();
        pickupTextController.SetActive(false);
        pickupTextKeyboard.SetActive(false);
    }

    private void Start()
    {
        score.SetScore();
        scoreText.text = "Picked Up: " + score.GetScore().GetValue(0).ToString() + "/" + score.GetScore().GetValue(1).ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base Mess" || other.tag == "Exploding Mess")
        {
            if (controllerDet.GetController() == 1)
                pickupTextController.SetActive(true);
            else
                pickupTextKeyboard.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Base Mess")
        {
            basicMess = other.GetComponent<BasicMessPickup>();
            if (Input.GetKey(KeyCode.E) || Input.GetAxis("Pickup") > 0)
            {
                //anim.SetBool("isPickingUp", true);
                basicMess.WasCollected();
                score.SetScore();
                scoreText.text = "Picked Up: " + score.GetScore().GetValue(0).ToString() + "/" + score.GetScore().GetValue(1).ToString();
                
                pickupTextController.SetActive(false);
                pickupTextKeyboard.SetActive(false);
                //anim.SetBool("isPickingUp", false);
            }

        }
        else if(other.tag == "Exploding Mess")
        {
            explodingMess = other.GetComponent<ExplodingMessPickup>();
            if (Input.GetKey(KeyCode.E) || Input.GetAxis("Pickup") > 0)
            {
                //anim.SetBool("isPickingUp", true);
                explodingMess.WasCollected();
                score.SetScore();
                scoreText.text = "Picked Up: " + score.GetScore().GetValue(0).ToString() + "/" + score.GetScore().GetValue(1).ToString();
                
                pickupTextController.SetActive(false);
                pickupTextKeyboard.SetActive(false);
                //anim.SetBool("isPickingUp", false);
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        pickupTextController.SetActive(false);
        pickupTextKeyboard.SetActive(false);
    }
}