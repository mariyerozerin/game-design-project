using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class OyunKontrol : MonoBehaviour
{
    public GameObject zombi;
    private float zamanSayaci;
    private float olusumSureci = 10f;
    public Text puanText;
    private int puan;

    // Start is called before the first frame update
    void Start()
    {
        zamanSayaci = olusumSureci; 
    }

    // Update is called once per frame
    void Update()
    {
        zamanSayaci -= Time.deltaTime;
        if (zamanSayaci < 0)
        {
            Vector3 pos = new Vector3(Random.Range(145f,364f), 22.5f, Random.Range(191f,361f));
            Instantiate(zombi, pos, Quaternion.identity);
            zamanSayaci = olusumSureci;
        }
    }

    public void PuanArtir(int p)
    {
        puan += p;
        puanText.text = "" + puan;
    }

    public void OyunBitti()
    {
        PlayerPrefs.SetInt("Puan", puan);
        SceneManager.LoadScene("OyunBitti");
    }
}
