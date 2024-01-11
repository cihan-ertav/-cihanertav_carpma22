using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Object = UnityEngine.Object;


public class DaireDonusManeger : MonoBehaviour
{
    
    

    string hangisonuc;
    GameManager gameManager;
    
    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "mermi"))
        {
            gameObject.transform.DORotate(transform.eulerAngles+Quaternion.AngleAxis(45,Vector3.forward).eulerAngles,0.5f);


            if (other.gameObject!=null)
            {
                Destroy(other.gameObject);
            }

            if (gameObject.name=="solDaire")
            {
                hangisonuc=GameObject.Find("solText").GetComponent<Text>().text;
            }
            else if (gameObject.name=="ortaDaire")
            {
                hangisonuc=GameObject.Find("ortaText").GetComponent<Text>().text;
            }
            else if (gameObject.name=="sagDaire")
            {
                hangisonuc=GameObject.Find("sagText").GetComponent<Text>().text;
            }
            
            //Debug.Log(hangisonuc);
            
            gameManager.sonucuKontrolEt(int.Parse(hangisonuc));
        }
           
            
       
    }
}
