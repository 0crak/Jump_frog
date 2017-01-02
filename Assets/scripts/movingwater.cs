using UnityEngine;
using System.Collections;

public class movingwater : MonoBehaviour {
    public GameObject zabka;
    private Renderer woda;
    public float scrollSpeed = 0.01F;
    private float staray, starax,a,b;

    void Start () {
        woda = GetComponent<Renderer>();
        a = zabka.transform.position.x;
        b = zabka.transform.position.z;
    }


    void Update() {
        transform.position = new Vector3(zabka.transform.position.x, transform.position.y, zabka.transform.position.z);
        if (starax!= zabka.transform.position.x || staray != zabka.transform.position.z)
        {
          //  Debug.Log("rozni sie");
        starax = zabka.transform.position.x;
        staray = zabka.transform.position.z;
        }
       float offset = Time.time * scrollSpeed;
        woda.material.SetTextureOffset("_MainTex", new Vector2(offset-(a+starax)/10, offset-(b+staray)/10));
    }
}
