using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Bruh : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("yo");
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string value = stream.ReadLine();
            Debug.Log(value);
    }
}
