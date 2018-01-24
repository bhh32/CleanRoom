using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : MonoBehaviour 
{
    protected bool isActive = true;
    protected bool isGrounded = false;

    // Returns Active State
    protected bool IsActive()
    {
        PickupCounter pickupCounter = GameObject.FindGameObjectWithTag("Pickup Counter").GetComponent<PickupCounter>();
        pickupCounter.AddToCurrentActivePickups();
        return this.isActive;
    }

    // Changes Active State
    protected void SetActive(bool NewActiveState)
    {
        gameObject.SetActive(NewActiveState);
    }

    // Set WasCollected State
    protected void WasCollected()
    {
        AddToPickedUp();
        string name = gameObject.tag;
        Debug.Log("You have collected a " + name);
    }

    // Ensure Pickup is grounded on the floor
    protected void IsGrounded()
    {        
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Physics.Raycast(ray, out hit);

        if (hit.transform == null)
        {
            PickupCounter pickupCounter = GameObject.FindGameObjectWithTag("Pickup Counter").GetComponent<PickupCounter>();
            pickupCounter.SubCurrentActivePickups();
            Destroy(gameObject);
        }
    }

    protected void AddToPickedUp()
    {
        PickupCounter pickupCounter = GameObject.FindGameObjectWithTag("Pickup Counter").GetComponent<PickupCounter>();
        pickupCounter.AddToPickedUpCounter();
    }
}
