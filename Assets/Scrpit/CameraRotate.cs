using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float mouseSen;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float xRotation;
    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -40f, 40f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mousex);
    }
}
