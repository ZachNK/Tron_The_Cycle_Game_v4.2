using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCall : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isClick;
    public int num;

    // Start is called before the first frame update
    private void Start()
    {
        isClick = false;
        num = 0;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
        num++;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
    }
}