using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float ySens;
    public float xSens;
    private float xRotation;
    private float yRotation;
    public bool canDetectCursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(DelayToCursor());
    }

    // Update is called once per frame
    void Update()
    {
        if(canDetectCursor)
        {
            horizontalInput = Input.GetAxis("Mouse X");
            verticalInput = Input.GetAxis("Mouse Y");

            xRotation += verticalInput * xSens;
            yRotation += horizontalInput * xSens;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            //yRotation = Mathf.Clamp(yRotation, -100f, -80f);

            transform.eulerAngles = new Vector3(xRotation, yRotation, transform.eulerAngles.z);
        }

    }

    IEnumerator DelayToCursor()
    {
        yield return new WaitForSeconds(0.5f);
        canDetectCursor = true;
    }    
}
