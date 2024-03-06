using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerChoosing : MonoBehaviour
{

    public GameObject whichObject;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private cameraScript script;

    // Start is called before the first frame update
    void Start()
    {
        cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        cinemachineVirtualCamera.m_Follow = whichObject.transform;
        script = GetComponent<cameraScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        disableChar();
        enableChar();
    }

    public void disableChar()
    {
        whichObject.SetActive(false);
    }
    public void enableChar()
    {
        whichObject.SetActive(true);
        whichObject.transform.position = cameraScript.Pos;
        cinemachineVirtualCamera.m_Follow = whichObject.transform;
    }
}
