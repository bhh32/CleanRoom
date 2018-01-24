using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetection : MonoBehaviour 
{
    private string[] names;
    [SerializeField] private int Xbox_Controller = 0;
	// Use this for initialization
	void Start () 
    {
        DetectCont();
	}

    void LateUpdate()
    {
        DetectCont();
    }

    void DetectCont()
    {
        names = Input.GetJoystickNames();
        if (names.Length > 0)
            for (int i = 0; i < names.Length; ++i)
            {
                if (!string.IsNullOrEmpty(names[i]))
                {
                    Xbox_Controller = 1;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else
                {
                    Xbox_Controller = 0;
                    if(!Cursor.visible)
                    {
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                    }
                }
            }
    }

    public int GetController()
    {
        return Xbox_Controller;
    }
}
