using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
    
public class DragScriptLevel2 : MonoBehaviour, IDragHandler, IBeginDragHandler,
    IEndDragHandler  {
    private RectTransform rectTransform;
    public Canvas canva;
    private CanvasGroup canvasGroup;
    public ObjectScriptLevel2 objectScriptLevel2;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void onPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(2) == false)
        {

            Debug.Log("Pointer Down: " + gameObject.name);
            objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[0]);

        }
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0) && Input.GetMouseButton(2) == false)
        {
            objectScriptLevel2.lastDragged = null;
            Debug.Log("Begin Drag: " + gameObject.name);
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
            rectTransform.SetSiblingIndex(12);

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging: " + gameObject.name);
        Vector2 mousePosition =
            new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePosition.x = Mathf.Clamp(
            mousePosition.x, 0 + rectTransform.rect.width / 2,
            Screen.width - rectTransform.rect.width / 2);

        mousePosition.y = Mathf.Clamp(
           mousePosition.y, 0 + rectTransform.rect.height / 2,
           Screen.height - rectTransform.rect.height / 2);

        transform.position = mousePosition;
    }
        public void OnEndDrag(PointerEventData eventData) {
        if(Input.GetMouseButtonUp(0)) 
            {

                Debug.Log("Dragging ended: " + gameObject.name);
            objectScriptLevel2.lastDragged = eventData.pointerDrag;
                canvasGroup.alpha = 1f;

            if (objectScriptLevel2.rightPlace == false)
            {
                canvasGroup.blocksRaycasts = true;
                objectScriptLevel2.audioSource.PlayOneShot(objectScriptLevel2.audioClips[0]);

            }
            else
            {
                objectScriptLevel2.lastDragged = null;
                
            }
            objectScriptLevel2.rightPlace = false;
        }
     }
 }
