using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMessPickup : BasePickup 
{
    private int score = 1;

    private void Start()
    {
        base.IsActive();
    }

    void Update()
    {
        IsGrounded();        
    }

    public int GetScore()
    {
        return score;
    }

    public void WasCollected()
    {
        base.WasCollected();
        SetActive(false);
    }
}
