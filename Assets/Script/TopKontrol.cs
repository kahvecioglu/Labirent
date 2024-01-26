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
    public float hýz = 10f;
    float zamansayacý = 15;
    int cansayacý = 2;
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
            zamansayacý -= Time.deltaTime;  // zamansayacý=zamansayacý-Time.deltaTime demek
            zaman.text = (int)zamansayacý + "";
        }
        else if (!oyunTamam)
        {
            durum.text = "Oyun Tamamlanamadý";
            btn.gameObject.SetActive(true);
        }
        if(zamansayacý<0)
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
            rb.AddForce(kuvvet * hýz);
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
            durum.text = ("Oyun Tamamlandý  Tebrikler");
            btn.gameObject.SetActive(true);

            if(sonrakiLevel.Equals("Son"))
            {
                SceneManager.LoadScene("AnaSahne");

            }
        }
        else if(!objeismi.Equals("zemin") && !objeismi.Equals("labirent zemini"))
        {
            cansayacý -= 1;
            can.text = cansayacý+"";
            if(cansayacý<1)
            {
                btn.gameObject.SetActive(true);
                oyunaDevam= false;
            }

        }
    }
}
