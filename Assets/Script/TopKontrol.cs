using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{   
    bool oyunTamam=false;
    bool oyunaDevam = true;
    public Text zaman, can,durum;
    private Rigidbody rb;
    public float h�z = 10f;
    float zamansayac� = 15;
    int cansayac� = 2;
    public Button btn;
    private float offset;
    public string sonrakiLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = Input.acceleration.z;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (oyunaDevam && !oyunTamam  )
        {
            zamansayac� -= Time.deltaTime;  // zamansayac�=zamansayac�-Time.deltaTime demek
            zaman.text = (int)zamansayac� + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamad�";
            btn.gameObject.SetActive(true);
        }
        if(zamansayac�<0)
        {
            btn.gameObject.SetActive(true);
            oyunaDevam=false;

        }
    }

    private void FixedUpdate()
    {  if (oyunaDevam && !oyunTamam)
        {
            //float yatay = Input.acceleration.x;
            //float dikey = Input.acceleration.z-offset;
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(-dikey, 0, yatay);
            rb.AddForce(kuvvet * h�z);
        }else
        {
            rb.velocity=Vector3.zero;
            rb.angularVelocity=Vector3.zero;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        string objeismi = collision.gameObject.name ;
        if(objeismi.Equals ("Bitis"))
        {
            PlayerPrefs.SetInt (sonrakiLevel, 1);
            SceneManager.LoadScene ("AnaSahne");
            
            oyunTamam = true;
            durum.text = ("Oyun Tamamland�  Tebrikler");
            btn.gameObject.SetActive(true);

            if(sonrakiLevel.Equals("Son"))
            {
                SceneManager.LoadScene("AnaSahne");

            }
        }
        else if(!objeismi.Equals("zemin") && !objeismi.Equals("labirent zemini"))
        {
            cansayac� -= 1;
            can.text = cansayac�+"";
            if(cansayac�<1)
            {
                btn.gameObject.SetActive(true);
                oyunaDevam= false;
            }

        }
    }
}
