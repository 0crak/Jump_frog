using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class liniaskoku : MonoBehaviour
{
    public float myVelocity = 20.0f;
    public float gravity = 9.81f;  
    public Material[] materials;  
    public int numberOfPoints = 20;
    private Transform cube;
    public Vector3[] points;
    public int shortLenght;
    public float totalDistance = 0.0f;
    public float max_top = 120f;
    public float max_bot = 30f;
    //private GameObject endofgame;
   
    public static float myVelocityPrzelicznik=0.11f;
    private GameObject rodzic;
    private float myVelocityStala = 20.0f;
    private RaycastHit hit;
    private LineRenderer linerender;
    private float width = 0.01f;
    private float myAngle;
    private float sinAngle;
    private int lenght;
    private float actual_angle = 40f;
    public static bool stopscript = false;
    private GameObject hitleaf;
    //private Fading sciemnianie;
    
    
    // public static bool animateTexture = true;
    //  public static float animationspeed = 2;
    //  public static Color textureColor;
    // public static int currentTexture=0;
    //private float currentAnimationOffset;
    // public GameObject render;
    // public Rigidbody projectile;

    void Start()
    {
      //  sciemnianie = GetComponent<Fading>();
        cube = GameObject.FindGameObjectWithTag("centrum").transform;
        rodzic= GameObject.FindGameObjectWithTag("centrum");
       // endofgame = GameObject.FindGameObjectWithTag("endgame");
       // endofgame.SetActive(false);
        linerender = GetComponent<LineRenderer>();
        linerender.SetWidth(width, width);
        stopscript = false;
    }
    void Update()
    {
        if (stopscript == false)
        {


          //  Debug.Log(myVelocityPrzelicznik);
           // Debug.Log(myVelocity);
            if (myVelocityPrzelicznik < 0.2f)
            {
                myVelocityPrzelicznik = 0.2f;
            }
            myVelocity = myVelocityPrzelicznik * myVelocityStala / 2;
            //Debug.Log("po prze" + myVelocityPrzelicznik);
           // Debug.Log("po v" + myVelocity);
            if (Input.GetKey(KeyCode.DownArrow) && actual_angle > max_bot)
            {
                transform.Rotate(Vector3.left);
                actual_angle -= 1;
                
            }
            if (Input.GetKey(KeyCode.UpArrow) && actual_angle < max_top)
            {
                transform.Rotate(Vector3.right);
                actual_angle += 1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            { cube.Rotate(Vector3.up);
              //  Debug.Log(cube.rotation);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            { cube.Rotate(-Vector3.up);
               // Debug.Log(cube.rotation);
            }

            myAngle = Mathf.Cos(((Vector3.Angle(transform.forward, cube.forward)+0.1f) / 100));
            sinAngle = Mathf.Sin(((Vector3.Angle(transform.forward, cube.forward) + 0.1f) / 100));
            points = new Vector3[numberOfPoints + 1];
            linerender.SetVertexCount(points.Length + 1);
            linerender.SetPosition(0, transform.position);
            lenght= numberOfPoints;

            if (shortLenght > 0)
            {
                lenght = shortLenght;
            }

            totalDistance = Vector3.Distance(transform.position, points[0]);

            for (int t = 0; t < lenght; t++)
            {

                points[t] = transform.position;
                var tempX = myVelocity * t * 0.2f * myAngle;
                points[t] = points[t] + cube.forward * tempX;
                var tempY = myVelocity * t * 0.2f * sinAngle - 0.2f * gravity * (Mathf.Pow(t * 0.2f + 0.01f, 2));
                points[t] = points[t] + cube.up * tempY;
                linerender.SetPosition(t + 1, points[t]);

                if (t > 0)
                {
                    if (Physics.Linecast(points[t], points[t - 1], out hit))
                    {
                        if (hit.transform.tag == "leaf")
                        {
                            
                            linerender.SetVertexCount(t + 2);
                            shortLenght = t + 2;
                            linerender.SetPosition(t + 1, hit.point);
                            points[t] = hit.point;
                            break;
                        }
                        if (hit.transform.tag == "solid")
                        {

                            linerender.SetVertexCount(t + 2);
                            shortLenght = t + 2;
                            linerender.SetPosition(t + 1, hit.point);
                            points[t] = hit.point;
                            break;
                        }

                    }

                    else
                    {
                        linerender.SetVertexCount(numberOfPoints + 1);
                        shortLenght = 0;
                    }
                   // if (t != (lenght - 1))
                    //{
                     //   totalDistance += Vector3.Distance(points[t], points[t - 1]); //Dodawanie odległości od kolejnych punktów linii
                    //}
                }
            }

            linerender.material.HasProperty("_Color");
            

            
            // linerender.SetWidth(width, width);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (hit.transform.tag=="leaf")
            {
                hitleaf = hit.transform.gameObject;
                count_points.dodaj = true;
                rodzic.GetComponent<projectileArc>().FollowPoints(points,lenght,hitleaf);
            }
            else
            {
                hitleaf = hit.transform.gameObject;
                if (hitleaf.CompareTag("solid"))
                {
                    CAMERA_FOLLOW_FROG.sledzenie_zabki = false;
                    Debug.Log("END OF GAME GOING SLEEP");
                    //endofgame.GetComponent<koniecgry>();
                    //endofgame.SetActive(true);                    
                }
                rodzic.GetComponent<projectileArc>().FollowPoints(points, lenght, hitleaf);
            }
                
        }
    }
}