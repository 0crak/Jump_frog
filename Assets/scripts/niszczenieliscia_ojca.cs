using UnityEngine;
using System.Collections;

public class niszczenieliscia_ojca : MonoBehaviour {

    public static bool skok_sie_odbyl_zniszcz_liscia = false; //idzie rozkaz gdzies od skoku
    public float szybkosc_zatapiania = 0.01f;
    private bool zatapiaj_liscia = false;
    void Update () {
       // Debug.Log(skok_sie_odbyl_zniszcz_liscia);
        if (skok_sie_odbyl_zniszcz_liscia == true)
        {
            
            StartCoroutine(Example());
        }
        if (zatapiaj_liscia==true)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, -21f, 0), szybkosc_zatapiania * Time.deltaTime);

        }

    }

    IEnumerator Example()
    {
        //  wyjebac = true;
        zatapiaj_liscia = true;
        skok_sie_odbyl_zniszcz_liscia = false;
        
        yield return new WaitForSeconds(3);

        zatapiaj_liscia = false;
        GameObject.Destroy(gameObject);
        


    }
}
