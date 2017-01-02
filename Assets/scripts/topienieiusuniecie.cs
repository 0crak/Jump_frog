using UnityEngine;
using System.Collections;

public class topienieiusuniecie : MonoBehaviour {
    public float szybkosc_zatapiania = 0.01f;
   // private bool wyjebac=false;
    // Use this for initialization
    void Start () {
       //lisc.AddComponent<topienieiusuniecie>();
      
    }

    void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -21f, 0), szybkosc_zatapiania * Time.deltaTime);

        StartCoroutine(Example());


    }

    IEnumerator Example()
    {
      //  wyjebac = true;
        yield return new WaitForSeconds(3);
        GameObject.Destroy(gameObject);
    }
}
