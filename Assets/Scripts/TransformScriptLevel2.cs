using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScriptLevel2 : MonoBehaviour
{
    public ObjectScriptLevel2 objectScriptLevel2;

    void Update()
    {
        if(objectScriptLevel2.lastDragged != null)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                    transform.Rotate(0, 0 , Time.deltaTime * 45f);
            }
            if (Input.GetKey(KeyCode.X))
            {
                objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                    transform.Rotate(0, 0, -Time.deltaTime * 45f);
            }

            if(Input.GetKey(KeyCode.UpArrow))
            {
                if (objectScriptLevel2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y < 1.5f)
                {
                    objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.x,
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.y + 0.01f);
                }
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (objectScriptLevel2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.y > 0.5f)
                {
                    objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.x,
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.y - 0.01f);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (objectScriptLevel2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x > 0.5f)
                {
                    objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.x - 0.01f,
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.y); ;
                }
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (objectScriptLevel2.lastDragged.
                    GetComponent<RectTransform>().transform.localScale.x < 1.5f)
                {
                    objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale = new Vector2(
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.x + 0.01f,
                        objectScriptLevel2.lastDragged.GetComponent<RectTransform>().
                        transform.localScale.y); ;
                }
            }
        }
    }
}
