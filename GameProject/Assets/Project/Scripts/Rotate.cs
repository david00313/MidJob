using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

        public float maxPitch = 20f;
    public float maxYaw = 80f;
    public float maxLookAngle = 10f;
    void Start()
    {
        
    }
    void Update()
    {
        Rotating();
    }

        public void Rotating(){

  
            float pitch = Input.GetAxis("Mouse Y");
            float yaw = Input.GetAxis("Mouse X");
            transform.localEulerAngles += new Vector3(-pitch, yaw, 0f);

            // Clamp pitch angle
            float currentPitch = transform.localEulerAngles.x;
            if (currentPitch > 180f) currentPitch -= 360f;
            currentPitch = Mathf.Clamp(currentPitch, -maxPitch, maxPitch);
            transform.localEulerAngles = new Vector3(currentPitch, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
