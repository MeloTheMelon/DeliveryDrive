using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyro;



    // Start is called before the first frame update
    void Start()
    {
        gyroEnabled = enableGyro();
        Debug.Log(gyroEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        if (gyroEnabled)
        {
            Vector3 rotation = gyro.attitude.eulerAngles;
            if (rotation.y < 330 && rotation.y > 280)
                Debug.Log("Left Turn");
            if (rotation.y > 30 && rotation.y < 90)
                Debug.Log("Right Turn");
            //Debug.Log(rotation);

        }
    }

    private bool enableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }
        return false;
    }

}
