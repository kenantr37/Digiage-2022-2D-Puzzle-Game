using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MirrorMovement : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    [SerializeField] Canvas canvas;
    [SerializeField] GameManager gameManager;

    [Header("Constructor")]
    public int _mirrorScore;
    public bool _scoreIncreased;
    public MirrorMovement(int score, bool scoreIncreased)
    {
        _mirrorScore = score;
        _scoreIncreased = scoreIncreased;
    }
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        _mirrorScore = 25;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        //canvasGroup.alpha = .6f;
        //canvasGroup.blocksRaycasts = false;
        canvasGroup.gameObject.transform.Rotate(Vector3.forward * 90);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag worked");

        canvasGroup.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("Drag's working");
        canvasGroup.alpha = .4f;
        canvasGroup.blocksRaycasts = false;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("drag's end");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        _mirrorScore = 25;

        try
        {
            if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Holder"))
            {
                _mirrorScore = -25;
            }
        }
        catch (Exception hata)
        {
            Debug.Log("Burada null hatasý var çöz sonra");
        }
    }
}