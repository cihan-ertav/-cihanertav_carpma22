using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject baslaresim;
    [SerializeField] private Text soruText;
    [SerializeField] private Text birincisonucText, ikincisonucText, ucuncusonucText;
    [SerializeField] private Text dogruAdetText, yanlisAdetText, toplamPuanText;
    [SerializeField] private GameObject dogruCevapResim, yanlisCevapResim;
    
    
    string hangiOyun;
   // string hangiToplamaOyunu;

    private int birincicarpan;
    int ikincicarpan;
    private int dogrucevap;
    
    int birinciyanliscevap;
    int ikinciyansliscevap;
    int ucuncuyanliscevap;
    
    
    public int dogruAdet, yanlisAdet,toplamPuan;
    
    PlayerManeger playerManeger;
    void Awake()
    {
        playerManeger = Object.FindObjectOfType<PlayerManeger>();
    }
    
    // Start is called before the first frame update
    void Start()//oyun başladığında hangi oyunun açılacağını belirler
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;
        dogruCevapResim.GetComponent<RectTransform>().localScale=Vector3.zero;
        yanlisCevapResim.GetComponent<RectTransform>().localScale=Vector3.zero;
        
        if (PlayerPrefs.HasKey("hangioyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangioyun");
            
        }
        
        
        StartCoroutine(baslayaresim());
        
    }
    
    IEnumerator baslayaresim()//oyun başlamadan önceki resim
    {
        
        baslaresim.GetComponent<CanvasGroup>().DOFade(1.3f,0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaresim.GetComponent<RectTransform>().DOScale(0,0.5f).SetEase(Ease.InBack);
        baslaresim.GetComponent<CanvasGroup>().DOFade(0,1f);
        yield return new WaitForSeconds(0.6f);
        
        oyunabasla();
    }

    void oyunabasla()
    {
        playerManeger.rotasyondegissinmi = true;
        soruyuYazdir();


       
        
        //birinciCarpaniAc();
        //Debug.Log("oyun başladı");
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void birinciCarpaniAc()//birinci çarpanda hangi oyunun açılacağını belirler
    {
        switch (hangiOyun)
        {
            case "iki":
                birincicarpan = 2;
                break;
            case "üç":
                birincicarpan = 3;
                break;
            case "dört":
                birincicarpan = 4;
                break;
            case "beş":
                birincicarpan = 5;
                break;
            case "altı":
                birincicarpan = 6;
                break;
            case "yedi":
                birincicarpan = 7;
                break;
            case "sekiz":
                birincicarpan = 8;
                break;
            case "dokuz":
                birincicarpan = 9;
                break;
            case "on":
                birincicarpan = 10;
                break;
            case "karışık":
                birincicarpan = Random.Range(2,11);
                break;
            case "top1":
                birincicarpan=Random.Range(1,10);
                break;
            case "top2":
                birincicarpan=Random.Range(10,100);
                break;
            case "top3":
                birincicarpan=Random.Range(100,1000);
                break;
            case "top4":
                birincicarpan=Random.Range(1000,10000);
                break;
            case "kartop":
                birincicarpan=Random.Range(1,1000);
                break;
            case "kolcikarma":
                birincicarpan=Random.Range(1,10);
                break;
            case "ortcikarma":
                birincicarpan=Random.Range(10,100);
                break;
            case "zorcikarma":
                birincicarpan=Random.Range(100,1000);
                break;
            case "karisikcikarma":
                birincicarpan=Random.Range(1,1000);
                break;
            
        }

        
        
        Debug.Log(hangiOyun);
        
    }

    
    void soruyuYazdir()
    {
        birinciCarpaniAc();
        
        if (hangiOyun == "top1" || hangiOyun == "top2" || hangiOyun == "top3" || hangiOyun == "top4" ||
            hangiOyun == "kartop")
        {

            if (birincicarpan < 10)
            {
                ikincicarpan = Random.Range(1, 10);
            }
            else if (birincicarpan < 100)
            {
                ikincicarpan = Random.Range(10, 100);
            }
            else 
            {
                ikincicarpan = Random.Range(100, 1000);
            }
            
            int rastgeledeger = Random.Range(1, 100);
            if (rastgeledeger <= 50)
            {
                soruText.text = birincicarpan.ToString() + "+" + ikincicarpan.ToString();
            }
            else
            {
                soruText.text = ikincicarpan.ToString() + "+" + birincicarpan.ToString();
            }
            dogrucevap = birincicarpan + ikincicarpan;
            sonucuYazdir();
            
            
        }
        else if (hangiOyun=="kolcikarma" || hangiOyun=="ortcikarma" || hangiOyun=="zorcikarma" || hangiOyun=="karisikcikarma")
        {
            if (birincicarpan<10)
            {
                ikincicarpan = Random.Range(1,10);
            }
            else if (birincicarpan<100)
            {
                ikincicarpan = Random.Range(10,100);
            }
            else
            {
                ikincicarpan = Random.Range(100,1000);
            }
            
            int rastgeledeger = Random.Range(1,100);
            if (rastgeledeger<=50)
            {
                soruText.text = birincicarpan.ToString()+"-"+ikincicarpan.ToString();
            }
            else
            {
                soruText.text = ikincicarpan.ToString()+"-"+birincicarpan.ToString();
            }

            dogrucevap = birincicarpan - ikincicarpan;
            sonucuYazdir();
        }
        
        else
        {

            ikincicarpan = Random.Range(2, 11);
            int rastgeledeger = Random.Range(1, 100);
            if (rastgeledeger <= 50)
            {
                soruText.text = birincicarpan.ToString() + "x" + ikincicarpan.ToString();
            }
            else
            {
                soruText.text = ikincicarpan.ToString() + "x" + birincicarpan.ToString();
            }

            dogrucevap = birincicarpan * ikincicarpan;
            sonucuYazdir();
        }
    }

    void sonucuYazdir()
    {
        birinciyanliscevap = dogrucevap + Random.Range(2,10);
        

        if (dogrucevap>10)
        {
            ikinciyansliscevap = dogrucevap - Random.Range(2,10);
        }
        else
        {
            ikinciyansliscevap = Mathf.Abs(dogrucevap + Random.Range(2, 10));

        }
        
        int rastgeledeger = Random.Range(1,100);

        if (rastgeledeger<=33)
        {
            birincisonucText.text = dogrucevap.ToString();
            ikincisonucText.text = birinciyanliscevap.ToString();
            ucuncusonucText.text = ikinciyansliscevap.ToString();
        }
        else if (rastgeledeger<=66)
        {
            ikincisonucText.text = dogrucevap.ToString();
            birincisonucText.text = birinciyanliscevap.ToString();
            ucuncusonucText.text = ikinciyansliscevap.ToString();
        }
        else
        {
            ucuncusonucText.text = dogrucevap.ToString();
            ikincisonucText.text = birinciyanliscevap.ToString();
            birincisonucText.text = ikinciyansliscevap.ToString();
        }
    }
    
    public void sonucuKontrolEt(int textsonuc)
    {
        dogruCevapResim.GetComponent<RectTransform>().localScale=Vector3.zero;
        yanlisCevapResim.GetComponent<RectTransform>().localScale=Vector3.zero;
        
        if (textsonuc==dogrucevap)
        {
            Debug.Log("doğru cevap");
            dogruAdet++;
            toplamPuan += 10;
            dogruCevapResim.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        }
        else
        {
            Debug.Log("yanlış cevap");
            yanlisAdet++;
            yanlisCevapResim.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
        }
        
        
        dogruAdetText.text = dogruAdet.ToString()+" Doğru";
        yanlisAdetText.text = yanlisAdet.ToString()+" Yanlış";
        toplamPuanText.text = toplamPuan.ToString()+" Puan";
        
        
        soruyuYazdir();
    }
    
}
