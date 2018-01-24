using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCounter : MonoBehaviour
{
    [SerializeField] private int pickedUpCounter = 0;
    [SerializeField] private int currentAmountOfPickups = 0;

	public void AddToPickedUpCounter()
    {
        pickedUpCounter++;
    }

    public int GetPickedUpCount()
    {
        return pickedUpCounter;
    }

    public void AddToCurrentActivePickups()
    {
        currentAmountOfPickups++;
    }

    public void SubCurrentActivePickups()
    {
        currentAmountOfPickups--;
    }

    public int GetActivePickups()
    {
        return currentAmountOfPickups;
    }
}
