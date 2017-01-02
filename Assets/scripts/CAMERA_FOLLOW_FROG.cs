using UnityEngine;
using System.Collections;

public class CAMERA_FOLLOW_FROG : MonoBehaviour {

    public GameObject zabka;
    public Camera kamera;
    public float smoothing = 5f;
    private Transform pozycja_zaby;
    public float rotat_speed=0.9f;
    public static bool sledzenie_zabki = true;
    private Transform kamerka_poczatek;
    public GameObject fading;
    Vector3 offset;
    void Start () {
        //pozycja_zaby = zabka.transform;
        // kamerka_poczatek = transform;
        fading.SetActive(false);
        offset = transform.position - zabka.transform.position;
        transform.position = zabka.transform.position + offset;
        sledzenie_zabki = true;
    }


    void Update()
    {

        // bool just_once = true;
        if (sledzenie_zabki)
        {
            //Quaternion rotata = zabka.transform.rotation;
            transform.LookAt(zabka.transform);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-Vector3.right * rotat_speed);
                offset = transform.position - zabka.transform.position;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * rotat_speed);
                offset = transform.position - zabka.transform.position;
            }

            transform.position = zabka.transform.position + offset;
        }
        else
        {
            fading.SetActive(true);
        }
    }
}

/*
var newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.forward);
    newRotation.x = 0.0;
    newRotation.y = 0.0;
    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime* 8);
          //  kamera.transform.rotation=new Quaternion(kamera.transform.rotation.x, kamera.transform.rotation.y+pozycja_zaby.transform.rotation.y, kamera.transform.rotation.z, kamera.transform.rotation.w); 
       //  transform.rotation = Quaternion.LookRotation(-kamera.transform.forward, kamera.transform.up);
        //  transform.rotation = new Quaternion(rotx,pozycja_zaby.rotation.y,rotz,rotw);
        //  var newRotation = Quaternion.LookRotation(transform.position - pozycja_zaby.position, Vector3.forward);
        //  newRotation.z = 0.0f;
        // newRotation.y = 0.0f;
    */
