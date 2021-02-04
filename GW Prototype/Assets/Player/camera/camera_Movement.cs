using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_Movement : MonoBehaviour
{
     [SerializeField]GameObject player;
    float xRotate, yRotate;
    [SerializeField] float sensitivity = 10f;
    Vector3 currentRotation, rotationSmoothVelocity;
    float rotationSmoothTime = 0.1f;
    Vector3 currentPos;

    void Start()
    {
        player = FindObjectOfType<player_Movement>().gameObject;
        transform.rotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        cameraInputs();
    }

    public void cameraInputs()
    {
        
        currentPos = gameObject.transform.position;
        yRotate += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        xRotate -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotate = Mathf.Clamp(xRotate, -30f, 70f);
        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(xRotate, yRotate), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;

    }
}
