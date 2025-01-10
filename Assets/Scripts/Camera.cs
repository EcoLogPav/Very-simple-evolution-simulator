using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Camera MCamera;
    public int CamPos = 0;

    void Start()
    {
        MCamera = GetComponent<Camera>();
        MCamera.transform.position = new Vector3(-17f, 15f, -25f);
        MCamera.transform.eulerAngles = new Vector3(40.716f, 43.544f, -0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            CamPos++;
        }
        if (CamPos == 0)
        {
            MCamera.transform.position = new Vector3(-17f, 15f, -25f);
            MCamera.transform.eulerAngles = new Vector3(40.716f, 43.544f, -0.001f);
        }
        else if (CamPos == 1)
        {
            MCamera.transform.position = new Vector3(2f, 22f, -6f);
            MCamera.transform.eulerAngles = new Vector3(90f, 0f, 0f);

        }
        else
        {
            CamPos = 0;
        }
    }
  public void SwitchPos()
    {
        CamPos++;
    }
}

