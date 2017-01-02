using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class textblink : MonoBehaviour {
    public Text wow;
    private float kolorr,kolorb,kolorg;
    private Color kolor;
    private float dalekosc = 50f;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    // Update is called once per frame
    void Start()
    {
        dalekosc = transform.localPosition.y;
    }
    void Update () {

        kolorr = Random.Range(0f, 1f);
        kolorb = Random.Range(0f, 1f);
        kolorg = Random.Range(0f, 1f);
        
        if (dalekosc-transform.localPosition.y<75)
        {
            transform.position = Vector3.SmoothDamp(transform.position, transform.position - new Vector3(0, 10, 0), ref velocity, smoothTime);
        }
    
        //transform.position = Mathf.Lerp(transform.position, transform.position + new Vector3(0, 50, 0),Time.deltaTime);
        kolor =new Color(kolorr, kolorb, kolorg);


        wow.color = kolor;
	}
}
