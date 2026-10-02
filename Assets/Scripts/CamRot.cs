using Unity.Mathematics;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    public float mouseSen = 100f;
    public Transform CamX;
    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSen;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSen;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        CamX.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * MouseX);

    }
}

