using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingInputs : MonoBehaviour
{
    public static TouchingInputs Instance;
    private void Awake()
    {
        Instance = this;
    }

    Transform holdingObjectTransform;
    bool holding = false;

    public bool inputEnabled = false;

    private void Update()
    {
        if(inputEnabled == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                LayerMask mask = LayerMask.GetMask("BodyPartTouch");

                Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touch.position);

                Vector3 correctedTouchWorldPosition = new Vector3(touchWorldPosition.x, touchWorldPosition.y, 0);

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, correctedTouchWorldPosition, Mathf.Infinity, mask);

                if (hit == true)
                {
                    if (holding == false)
                    {
                        holdingObjectTransform = hit.collider.gameObject.transform.parent;
                        holding = true;
                    }

                    holdingObjectTransform.position = correctedTouchWorldPosition;
                }
            }
            else
            {
                holding = false;
                holdingObjectTransform = null;
            }
        }
    }
}
