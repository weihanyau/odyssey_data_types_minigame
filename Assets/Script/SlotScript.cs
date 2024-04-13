using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IDropHandler
{
    public int id;
    [SerializeField] private AudioSource sourceSlot;
    [SerializeField] private AudioClip itemDropClip, itemDropFalseClip;



    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Item droppp");
        if (eventData.pointerDrag != null && !eventData.pointerDrag.GetComponent<DragandDrop>().correct)
        {
            if (eventData.pointerDrag.GetComponent<DragandDrop>().id == id)
            {
                sourceSlot.PlayOneShot(itemDropClip);
                eventData.pointerDrag.GetComponent<DragandDrop>().correct = true;
                WinChecker.correctCount++;
                Debug.Log("Correct");
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;

            }
            else
            {
                sourceSlot.PlayOneShot(itemDropFalseClip);
                eventData.pointerDrag.GetComponent<DragandDrop>().correct = false;
                Debug.Log("False");
                eventData.pointerDrag.GetComponent<DragandDrop>().ResetPosition();
            }
        }
    }
}

