using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MirrorHolder : MonoBehaviour, IDropHandler
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] GameManager gameManager;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Ondrop worked");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.gameObject.GetComponent<BoxCollider2D>().enabled = true;

            soundManager.MirrorPuttingSound();
        }

    }
}