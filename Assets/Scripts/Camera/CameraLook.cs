using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour 
{
    [SerializeField] private GameObject player;
    private float offsetX;
    private float offsetY;
    private float offsetZ;

    void Start()
    {
        offsetX = transform.localPosition.x - player.transform.position.x;
        offsetY = transform.localPosition.y - player.transform.position.y;
        offsetZ = transform.localPosition.z - player.transform.position.z;
    }

	// Update is called once per frame
	void LateUpdate () 
    {
        transform.localPosition = new Vector3(player.transform.localPosition.x + offsetX, player.transform.localPosition.y + offsetY, offsetZ);
        transform.LookAt(player.transform);
	}
}
