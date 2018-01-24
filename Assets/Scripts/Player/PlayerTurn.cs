using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour 
{
    [SerializeField] private float turnSpeed = 150f;
    [SerializeField] float controllerX = 0f;
    [SerializeField] float controllerY = 0f;
    [SerializeField] ControllerDetection contDect;
	
	// Update is called once per frame
	void Update () 
    {
        float mouseX = Input.GetAxis("Mouse X") * turnSpeed * 3f;

        controllerX = Input.GetAxis("Turn Right") * turnSpeed * 2f;
        controllerY = Input.GetAxis("Look Up") * turnSpeed;

        if (controllerX > 0 || controllerX < 0)
            transform.Rotate(0f, controllerX * Time.deltaTime, 0f);

        if (contDect.GetController() == 0)
        {
            if (mouseX > 0 || mouseX < 0)
                transform.Rotate(0f, mouseX * Time.deltaTime, 0f);
        }

        if (controllerY > 0 || controllerY < 0)
            Camera.main.transform.Translate(0f, controllerY * Time.deltaTime, 0f);
	}
}
