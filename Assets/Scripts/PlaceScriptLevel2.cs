using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScriptLevel2 : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScriptLevel2 objectScriptLevel2;

    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && Input.GetMouseButtonUp(0)
            && Input.GetMouseButton(2) == false) { }

        if (eventData.pointerDrag.tag.Equals(tag))
        {
            placeZRotation = eventData.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
            carZRotation = GetComponent<RectTransform>().transform.eulerAngles.z;
            difZRotation = Mathf.Abs(placeZRotation - carZRotation);

            placeSize = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
            carSize = GetComponent<RectTransform>().localScale;
            xSizeDif = Mathf.Abs(placeSize.x - carSize.x);
            ySizeDif = Mathf.Abs(placeSize.y - carSize.y);

            if ((difZRotation <= 10 || (difZRotation >= 350 && difZRotation <= 360)) &&
                (xSizeDif <= 0.1f && ySizeDif <= 0.1f))
            {
                objectScriptLevel2.rightPlace = true;

                
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
                    GetComponent<RectTransform>().localRotation;
                eventData.pointerDrag.GetComponent<RectTransform>().localScale =
                    GetComponent<RectTransform>().localScale;

                
                switch (eventData.pointerDrag.tag)
                {
                    case "tungtung": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;
                    case "chimpanzini": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;
                    case "sports": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;
                    case "tank": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;
                    case "tralala": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;
                    case "brr": objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[2]); break;

                    default: Debug.LogError("Unknown tag!"); break;
                }

                
                objectScriptLevel2.correctCount++;
                if (objectScriptLevel2.correctCount >= 12)
                {
                    objectScriptLevel2.timerDisplay.StopTimer();
                    float finalTime = objectScriptLevel2.timerDisplay.GetTime();
                    objectScriptLevel2.completionScreen.ShowCompletion(finalTime);
                }
            }
        }
        else
        {
            objectScriptLevel2.rightPlace = false;
            objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[1]);

            switch (eventData.pointerDrag.tag)
            {
                case "tungtung": objectScriptLevel2.tungtung.GetComponent<RectTransform>().localPosition = objectScriptLevel2.tungtungPos; break;
                case "chimpanzini": objectScriptLevel2.chimpanzini.GetComponent<RectTransform>().localPosition = objectScriptLevel2.chimpanziniPos; break;
                case "sports": objectScriptLevel2.sports.GetComponent<RectTransform>().localPosition = objectScriptLevel2.sportsPos; break;
                case "tank": objectScriptLevel2.tank.GetComponent<RectTransform>().localPosition = objectScriptLevel2.tankPos; break;
                case "tralala": objectScriptLevel2.tralala.GetComponent<RectTransform>().localPosition = objectScriptLevel2.tralalaPos; break;
                case "brr": objectScriptLevel2.brr.GetComponent<RectTransform>().localPosition = objectScriptLevel2.brrPos; break;

                default: Debug.LogError("Unknown tag!"); break;
            }
        }
    }
}
