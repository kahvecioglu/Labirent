using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    // Start is called before the first frame update
   

    public void YenidenBasla()
    {

        SceneManager.LoadScene("Level1");

    }
    public void YenidenBasla2()
    {

        SceneManager.LoadScene("Level2");

    }
    public void YenidenBasla3()
    {

        SceneManager.LoadScene("Level3");

    }
}
