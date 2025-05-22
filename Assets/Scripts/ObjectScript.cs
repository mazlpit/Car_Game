using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public TimerDisplay timerDisplay;
    public CompletionScreen completionScreen;
    [HideInInspector] public int correctCount = 0;

    public GameObject garbageTruck;
    public GameObject schoolBus;
    public GameObject medic;
    public GameObject b2;
    public GameObject e46;
    public GameObject e61;
    public GameObject excavator;
    public GameObject fireTruck;
    public GameObject farmingTractor;
    public GameObject cementTruck;
    public GameObject diggingTractor;
    public GameObject police;

    [HideInInspector] public Vector2 gTruckPos;
    [HideInInspector] public Vector2 sBusPos;
    [HideInInspector] public Vector2 medicPos;
    [HideInInspector] public Vector2 b2Pos;
    [HideInInspector] public Vector2 e46Pos;
    [HideInInspector] public Vector2 e61Pos;
    [HideInInspector] public Vector2 excavatorPos;
    [HideInInspector] public Vector2 fireTruckPos;
    [HideInInspector] public Vector2 farmingTractorPos;
    [HideInInspector] public Vector2 cementTruckPos;
    [HideInInspector] public Vector2 diggingTractorPos;
    [HideInInspector] public Vector2 policePos;

    public AudioSource audioSource;
    public AudioClip[] audioClips;

    [HideInInspector] public bool rightPlace = false;
    public GameObject lastDragged = null;



    void Start()
    {
        gTruckPos = garbageTruck.GetComponent<RectTransform>().localPosition;
        sBusPos = schoolBus.GetComponent<RectTransform>().localPosition;
        medicPos = medic.GetComponent<RectTransform>().localPosition;
        b2Pos = b2.GetComponent<RectTransform>().localPosition;
        e46Pos = e46.GetComponent<RectTransform>().localPosition;
        e61Pos = e61.GetComponent<RectTransform>().localPosition;
        excavatorPos = excavator.GetComponent<RectTransform>().localPosition;
        fireTruckPos = fireTruck.GetComponent<RectTransform>().localPosition;
        farmingTractorPos = farmingTractor.GetComponent<RectTransform>().localPosition;
        cementTruckPos = cementTruck.GetComponent<RectTransform>().localPosition;
        diggingTractorPos = diggingTractor.GetComponent<RectTransform>().localPosition;
        policePos = police.GetComponent<RectTransform>().localPosition;
    }
}
