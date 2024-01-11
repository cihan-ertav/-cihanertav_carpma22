using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerManeger : MonoBehaviour
{
    [SerializeField] private Transform silah;
    [SerializeField] private Transform mermiCikisYeri;

    [SerializeField] private GameObject[] mermiPrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    float angle;
    float donushizi = 5f;
    
    float ikimermiarasisure = 200f;
    private float sonrakimermi;
    
    public bool rotasyondegissinmi;
    
   
    
    // Start is called before the first frame update
    void Start()
    {
        rotasyondegissinmi = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotasyondegissinmi)
        {
            rotasyon();
        }
        //rotasyon();
    }
    
    void rotasyon()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - silah.transform.position;
        
        angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg-90;

        if (angle<45 && angle>-45)
        {
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            
            silah.transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            //silah.transform.rotation = Quaternion.Slerp(silah.transform.rotation,rotation,donushizi * Time.deltaTime);

        }
        
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            
            
            if (Time.time > sonrakimermi)
            {
                sonrakimermi = Time.time + ikimermiarasisure / 1000;
                atesEt();
            }
        }
        
        
    }
    
    
    public void atesEt()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)],mermiCikisYeri.position,mermiCikisYeri.rotation);
        mermi.GetComponent<Rigidbody2D>().AddForce(mermiCikisYeri.up * 500f);
        //mermiler 5 saniye sonra yok olsun
        Destroy(mermi,5f);
    }
}
