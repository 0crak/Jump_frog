using UnityEngine;
using System.Collections;

public class testowyscrypt : MonoBehaviour {

    public GameObject zaba;
    public Camera kamera;
     
        void Start()
    {

    }
    void Update()
    {
        kamera.transform.LookAt(zaba.transform);
        
    }
}
