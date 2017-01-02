using UnityEngine;
using System.Collections;

public class projectileArc : MonoBehaviour
{
    
    public Vector3[] points = new Vector3[35];
    public bool draw = true;
    public int count = 0;
    public Vector3[] followPoints;
    public static bool follow = false;
    public int currentWaypoint = 1;
    public float speed = 0.1f;
    private float currentSpeed;
    public float timeBetweenPoints = .2f;
    private Vector3[] poin;
    private GameObject lisciu_moj;
    private int len;
    
    // Use this for initialization
    void Start()
    {
        Debug.Log("first time");
        follow = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (follow)
        {
            
            
            if (currentWaypoint < followPoints.Length-1)
            {
                followPoints[followPoints.Length - 3] = Vector3.Lerp(followPoints[followPoints.Length - 3], followPoints[followPoints.Length - 2],0);
                followPoints[followPoints.Length - 2] = lisciu_moj.transform.position+new Vector3(0,0.5f,0);
                transform.position = Vector3.Lerp(followPoints[currentWaypoint - 1], followPoints[currentWaypoint], currentSpeed);
                currentSpeed += speed;
                //Leci przez wszystkie punkty, dwa przed ostatnie muszą ja prowadzić na środek liścia czyli
                // lisciu_moj.transform.position
                if (transform.position == followPoints[currentWaypoint])
                {
                    currentWaypoint++;
                    currentSpeed = 0;
                }

            }
            
                
           //to działa ale chuj wie czemu
            else
            {
                //  Debug.Log("lisc"+lisciu_moj.transform.position);
                transform.position = Vector3.Lerp(followPoints[currentWaypoint - 1], lisciu_moj.transform.position, currentSpeed);
                // Debug.Log(lisciu_moj.transform.position);
                // Debug.Log("co to "+lisciu_moj);
                currentSpeed += speed;

                //wysylamy powiadomienie do Houston
                //putleafs.rob
                //putleafs.rozruchskryptu(lisciu_moj);
                GameObject theleaf = GameObject.Find("leafsgroup");
                putleafs leafscript = theleaf.GetComponent<putleafs>();
                leafscript.rozruchskryptu(lisciu_moj);
                frogjump.dawajDalej = true;
                follow = false;
               // Debug.Log("TRWA");
            }
        }
    }
    public void FollowPoints (Vector3[] poin,int len,GameObject lisciu)
    {
        lisciu_moj = lisciu;
        followPoints = new Vector3[len];
        for(int i=0;i< len; i++)
        {
            followPoints[i] = poin[i];
        }
        follow = true;
        
    }
}