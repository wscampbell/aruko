using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinchableScrollRect : ScrollRect
{
    float minZoom = .4f;
    float maxZoom = 1;
    float zoomSpeed = 10f;
    float currZoom = 1;
    
    bool pinching = false;
    float startPinchDistance;
    float startPinchZoom;
    Vector2 startPinchCenter;
    Vector2 startPinchScreenPosition;

    float mouseWheelSensitivity = 1;
    bool blockPan = false;

    protected override void Awake()
    {
        Input.multiTouchEnabled = true;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            if (!pinching)
            {
                pinching = true;
                OnPinchStart();
            }
            OnPinch();
        }
        else
        {
            pinching = false;
            if(Input.touchCount == 0)
            {
                blockPan = false;
            }
        }

        // pc input
        float scrollWheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scrollWheelInput) > float.Epsilon)
        {
            currZoom *= 1 + scrollWheelInput * mouseWheelSensitivity;
            currZoom = Mathf.Clamp(currZoom, minZoom, maxZoom);
            startPinchScreenPosition = (Vector2)Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(content, startPinchScreenPosition, null, out startPinchCenter);
            Vector2 pivotPosition = new Vector3 (content.pivot.x * content.rect.size.x, content.pivot.y * content.rect.size.y);
            Vector2 posFromBottomLeft = pivotPosition + startPinchCenter;
            SetPivot(content, new Vector2(posFromBottomLeft.x / content.rect.width, posFromBottomLeft.y / content.rect.height));
        }
        // end pc input

        if (Mathf.Abs(content.localScale.x - currZoom) > .001f)
            content.localScale = Vector3.Lerp(content.localScale, Vector3.one * currZoom, zoomSpeed * Time.deltaTime);
    }

    protected override void SetContentAnchoredPosition(Vector2 position)
    {
        if (pinching || blockPan) return;
        base.SetContentAnchoredPosition(position);
    }

    void OnPinchStart()
    {
        Vector2 pos1 = Input.touches[0].position;
        Vector2 pos2 = Input.touches[1].position;

        startPinchDistance = Distance(pos1, pos2) * content.localScale.x;
        startPinchZoom = currZoom;
        startPinchScreenPosition = (pos1 + pos2) / 2;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, startPinchScreenPosition, null, out startPinchCenter);

        Vector2 pivotPosition = new Vector3 (content.pivot.x * content.rect.size.x, content.pivot.y * content.rect.size.y);
        Vector2 posFromBottomLeft = pivotPosition + startPinchCenter;

        SetPivot(content, new Vector2(posFromBottomLeft.x / content.rect.width, posFromBottomLeft.y / content.rect.height));
        blockPan = true;
    }

    void OnPinch()
    {
        float currPinchDist = Distance(Input.touches[0].position, Input.touches[1].position) * content.localScale.x;
        currZoom = (currPinchDist / startPinchDistance) * startPinchZoom;
        currZoom = Mathf.Clamp(currZoom, minZoom, maxZoom);
    }

    float Distance(Vector2 pos1, Vector2 pos2)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, pos1, null, out pos1);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(content, pos2, null, out pos2);
        return Vector2.Distance(pos1, pos2);
    }

    static void SetPivot(RectTransform rectTransform, Vector2 pivot)
    {
        if (rectTransform == null) return;

        Vector2 size = rectTransform.rect.size;
        Vector2 deltaPivot = rectTransform.pivot - pivot;
        Vector3 deltaPosition = new Vector3(deltaPivot.x * size.x, deltaPivot.y * size.y) * rectTransform.localScale.x;
        rectTransform.pivot = pivot;
        rectTransform.localPosition -= deltaPosition;
    }
}
