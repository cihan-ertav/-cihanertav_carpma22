using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Object = UnityEngine.Object;

public class SonucManeger : MonoBehaviour
{
    
    [SerializeField] private Image sonucImage;
    [SerializeField] private Text dogruText, yanlisText, puanText;
    [SerializeField] private GameObject tekrarOynaButton, anamenuyeDonButton;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private float suretimer;
    bool resimacilsinmi;
    
    GameManager gameManager;

    private void Awake()
    {
        gameManager =Object.FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        suretimer = 0;
        resimacilsinmi = true;
        
        

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";
        
        tekrarOynaButton.GetComponent<RectTransform>().localScale=Vector3.zero;
        anamenuyeDonButton.GetComponent<RectTransform>().localScale=Vector3.zero; 
        StartCoroutine(resimacrutine());
    }

    // Start is called before the first frame update
    /*void Start()
    {
        suretimer = 0;
        resimacilsinmi = true;
        
        

        dogruText.text = "";
        yanlisText.text = "";
        puanText.text = "";
        
        tekrarOynaButton.GetComponent<RectTransform>().localScale=Vector3.zero;
        anamenuyeDonButton.GetComponent<RectTransform>().localScale=Vector3.zero;
    }*/

    IEnumerator resimacrutine()
    {
        while (resimacilsinmi)
        {
            suretimer += .15f;
            sonucImage.fillAmount = suretimer;
            yield return new WaitForSeconds(.1f);
            
            if (suretimer>=1)
            {
                resimacilsinmi = false;
                suretimer = 1;

                dogruText.text =gameManager.dogruAdet.ToString()+" Doğru";
                yanlisText.text = gameManager.yanlisAdet.ToString()+" Yanlış";
                puanText.text = gameManager.toplamPuan.ToString()+" Puan";
                
                tekrarOynaButton.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
                anamenuyeDonButton.GetComponent<RectTransform>().DOScale(1,0.5f).SetEase(Ease.OutBack);
            }
        }
    }
    
    public void tekrarOyna()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        SceneManager.LoadScene("GameLevel");
    }
    
    public void anamenuyeDon()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        SceneManager.LoadScene("IslemlerSayfa");
    }
}
