using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragandDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private RectTransform rectTrans;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    public int id;
    private Vector2 initPos;
    public bool correct;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickupClip, dropClip;


    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initPos = transform.position;
        correct = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (correct)
        {
            return;
        }
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        // source.PlayOneShot(dropClip);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Click");
        source.PlayOneShot(pickupClip);

    }

    public void ResetPosition()
    {
        transform.position = initPos;
    }
    public void newPosition()
    {
        initPos = transform.position;
    }
}
