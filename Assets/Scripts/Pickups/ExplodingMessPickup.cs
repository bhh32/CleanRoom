using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingMessPickup : BasePickup
{
    [SerializeField] private GameObject expolsion;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject[] basicMess;
    private Vector3 spawnPos;
    private Rigidbody rb;

    private int score = 5;

    private void Start()
    {
        base.IsActive();
        rb = GetComponent<Rigidbody>();
        
    }

    public int GetScore()
    {
        return score;
    }

    public void WasCollected()
    {
        base.WasCollected();

        Vector3 explosionPos = transform.position;
        rb.AddExplosionForce(20f, explosionPos, 30f);
        GameObject boom = Instantiate(expolsion, gameObject.transform.position, gameObject.transform.rotation);
            audioSource.Play();

        foreach (GameObject mess in basicMess)
        {
            spawnPos = new Vector3(transform.position.x * Random.Range(-10f, 10f), 
                                                           .26f, 
                                                           transform.position.z * Random.Range(-10f, 10f));
            Quaternion spawnRot = gameObject.transform.rotation;
            GameObject messy = Instantiate(mess, spawnPos, spawnRot) as GameObject;
        }

        SetActive(false);
    }
}
