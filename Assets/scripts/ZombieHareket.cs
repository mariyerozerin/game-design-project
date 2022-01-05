using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieHareket : MonoBehaviour
{
    public GameObject kalp;
    private GameObject oyuncu;
    private int zombieCan=1;
    private int zombidenGelenPuan = 10;
    private float mesafe;
    private OyunKontrol oKontrol;
    private AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("oyuncu");
        oKontrol = GameObject.Find("_Scripts").GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;
        mesafe = Vector3.Distance(transform.position, oyuncu.transform.position);
        if(mesafe < 10f)
        {
            if(!aSource.isPlaying)
            aSource.Play();
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
        else
        {
            if (aSource.isPlaying)
            aSource.Stop();
        }


    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.gameObject.tag.Equals("mermi"))
        {
            Debug.Log("Carpisma Gercekleti");
            zombieCan--;
            if(zombieCan ==0)
            {
                oKontrol.PuanArtir(zombidenGelenPuan);
                Instantiate(kalp, transform.position, Quaternion.identity);
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(this.gameObject, 1.667f);
            }
        }
    }
}
