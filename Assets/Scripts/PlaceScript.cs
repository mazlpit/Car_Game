using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript : MonoBehaviour, IDropHandler
{
    private float placeZRotation, carZRotation, difZRotation;
    private Vector2 placeSize, carSize;
    private float xSizeDif, ySizeDif;
    public ObjectScript objectScript;

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
                (xSizeDif <= 0.2 && ySizeDif <= 0.2))
            {
                objectScript.rightPlace = true;

                // Align position/rotation/scale
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                    GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<RectTransform>().localRotation =
                    GetComponent<RectTransform>().localRotation;
                eventData.pointerDrag.GetComponent<RectTransform>().localScale =
                    GetComponent<RectTransform>().localScale;

                // Play correct sound
                switch (eventData.pointerDrag.tag)
                {
                    case "Garbage": objectScript.audioSource.PlayOneShot(objectScript.audioClips[2]); break;
                    case "Medic": objectScript.audioSource.PlayOneShot(objectScript.audioClips[4]); break;
                    case "School": objectScript.audioSource.PlayOneShot(objectScript.audioClips[3]); break;
                    case "b2": objectScript.audioSource.PlayOneShot(objectScript.audioClips[5]); break;
                    case "e46": objectScript.audioSource.PlayOneShot(objectScript.audioClips[11]); break;
                    case "e61": objectScript.audioSource.PlayOneShot(objectScript.audioClips[12]); break;
                    case "Excavator": objectScript.audioSource.PlayOneShot(objectScript.audioClips[10]); break;
                    case "Fire": objectScript.audioSource.PlayOneShot(objectScript.audioClips[11]); break;
                    case "Farm": objectScript.audioSource.PlayOneShot(objectScript.audioClips[6]); break;
                    case "Cement": objectScript.audioSource.PlayOneShot(objectScript.audioClips[13]); break;
                    case "Digging": objectScript.audioSource.PlayOneShot(objectScript.audioClips[7]); break;
                    case "Police": objectScript.audioSource.PlayOneShot(objectScript.audioClips[9]); break;
                    default: Debug.LogError("Unknown tag!"); break;
                }

                // Increment correct count and stop timer if all are placed
                objectScript.correctCount++;
                if (objectScript.correctCount >= 12)
                {
                    objectScript.timerDisplay.StopTimer();
                    Debug.Log(" All cars have been placed! Timer stopped.");
                }
            }
        }
        else
        {
            objectScript.rightPlace = false;
            objectScript.audioSource.PlayOneShot(objectScript.audioClips[1]);

            // Reset position on incorrect placement
            switch (eventData.pointerDrag.tag)
            {
                case "Garbage": objectScript.garbageTruck.GetComponent<RectTransform>().localPosition = objectScript.gTruckPos; break;
                case "Medic": objectScript.medic.GetComponent<RectTransform>().localPosition = objectScript.medicPos; break;
                case "School": objectScript.schoolBus.GetComponent<RectTransform>().localPosition = objectScript.sBusPos; break;
                case "b2": objectScript.b2.GetComponent<RectTransform>().localPosition = objectScript.b2Pos; break;
                case "e46": objectScript.e46.GetComponent<RectTransform>().localPosition = objectScript.e46Pos; break;
                case "e61": objectScript.e61.GetComponent<RectTransform>().localPosition = objectScript.e61Pos; break;
                case "Excavator": objectScript.excavator.GetComponent<RectTransform>().localPosition = objectScript.excavatorPos; break;
                case "Fire": objectScript.fireTruck.GetComponent<RectTransform>().localPosition = objectScript.fireTruckPos; break;
                case "Farm": objectScript.farmingTractor.GetComponent<RectTransform>().localPosition = objectScript.farmingTractorPos; break;
                case "Cement": objectScript.cementTruck.GetComponent<RectTransform>().localPosition = objectScript.cementTruckPos; break;
                case "Digging": objectScript.diggingTractor.GetComponent<RectTransform>().localPosition = objectScript.diggingTractorPos; break;
                case "Police": objectScript.police.GetComponent<RectTransform>().localPosition = objectScript.policePos; break;
                default: Debug.LogError("Unknown tag!"); break;
            }
        }
    }
}