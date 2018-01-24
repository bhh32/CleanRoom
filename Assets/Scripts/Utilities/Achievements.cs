using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    [SerializeField] private Image bronzeStar;
    [SerializeField] private Image silverStar;
    [SerializeField] private Image goldStar;
    [SerializeField] private Sprite emptyStar;
    [SerializeField] private Sprite fullBronze;
    [SerializeField] private Sprite fullSilver;
    [SerializeField] private Sprite fullGold;

    private PickupCounter pickupCounterObj;
    private int pickupCounter;
    private int goal;

    private bool hasBronze = false;
    private bool hasSilver = false;
    private bool hasGold = false;

    // Use this for initialization
    void Start ()
    {
        // Set all star sprites to empty
        bronzeStar.sprite = emptyStar;
        silverStar.sprite = emptyStar;
        goldStar.sprite = emptyStar;

        // Get the pickup counter script and set the ints to the appropriate value
        pickupCounterObj = GameObject.FindGameObjectWithTag("Pickup Counter").GetComponent<PickupCounter>();
        pickupCounter = pickupCounterObj.GetPickedUpCount();
        goal = pickupCounterObj.GetActivePickups();
	}
	
	void LateUpdate ()
    {
        // Update the achievement system
        UpdateAchievements();
	}

    void UpdateAchievements()
    {
        // Update the pickupCounter and goal variables
        pickupCounter = pickupCounterObj.GetPickedUpCount();
        goal = pickupCounterObj.GetActivePickups();

        if (!hasBronze)
        {
            if(BronzeStar())
            {
                bronzeStar.sprite = fullBronze;
                hasBronze = true;
            }
        }
        else if(!hasSilver)
        {
            if(SilverStar())
            {
                silverStar.sprite = fullSilver;
                hasSilver = true;
            }
        }
        else if(!hasGold)
        {
            if(GoldStar())
            {
                goldStar.sprite = fullGold;
                hasGold = true;
            }
        }
    }

    bool BronzeStar()
    {
        bool hasBronze = false;

        if (pickupCounter >= goal / 3)
            hasBronze = true;

        return hasBronze;
    }

    bool SilverStar()
    {
        bool hasSilver = false;

        if (pickupCounter >= goal / 2)
            hasSilver = true;

        return hasSilver;
    }

    bool GoldStar()
    {
        bool hasGold = false;

        if (pickupCounter == goal)
            hasGold = true;

        return hasGold;
    }
}
