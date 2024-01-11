using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class MenuManeger : MonoBehaviour
{
    [SerializeField] private GameObject menupanel;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] private GameObject sesPaneli;
    
    bool sespaneliacikmi;
    
    // Start is called before the first frame update
    void Start()
    {
        sespaneliacikmi = false;
        sesPaneli.GetComponent<RectTransform>().localPosition=new Vector3(0,-216,0);
        menupanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menupanel.GetComponent<RectTransform>().DOScale(1,1f).SetEase(Ease.OutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void ikiciMenuyeGec()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        
        
        SceneManager.LoadScene("IslemlerSayfa");
    }
    
    public void ayarlarMenuyeGec()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        if (!sespaneliacikmi)
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-387,0.5f).SetEase(Ease.OutBack);
            sespaneliacikmi = true;
        }
        else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-216,0.5f).SetEase(Ease.InBack);
            sespaneliacikmi = false;
        }
    }
    public void cıkıs()
    {
        if (PlayerPrefs.GetInt("sesdurumu")==1)
        {
            audioSource.PlayOneShot(audioClip); 
        }
        Application.Quit();
    }
}
