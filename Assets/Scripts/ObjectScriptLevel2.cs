using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScriptLevel2 : MonoBehaviour
{
    public TimerDisplay timerDisplay;
    public CompletionScreen completionScreen;
    [HideInInspector] public int correctCount = 0;

    public GameObject tungtung;
    public GameObject chimpanzini;
    public GameObject sports;
    public GameObject tank;
    public GameObject tralala;
    public GameObject brr;
    

    [HideInInspector] public Vector2 tungtungPos;
    [HideInInspector] public Vector2 chimpanziniPos;
    [HideInInspector] public Vector2 sportsPos;
    [HideInInspector] public Vector2 tankPos;
    [HideInInspector] public Vector2 tralalaPos;
    [HideInInspector] public Vector2 brrPos;




    public AudioSource audioSource;
    public AudioClip[] audioClips;

    [HideInInspector] public bool rightPlace = false;
    public GameObject lastDragged = null;



    void Start()
    {
        tungtungPos = tungtung.GetComponent<RectTransform>().localPosition;
        chimpanziniPos = chimpanzini.GetComponent<RectTransform>().localPosition;
        sportsPos = sports.GetComponent<RectTransform>().localPosition;
        tankPos = tank.GetComponent<RectTransform>().localPosition;
        tralalaPos = tralala.GetComponent<RectTransform>().localPosition;
        brrPos = brr.GetComponent<RectTransform>().localPosition;
       
    }
}
