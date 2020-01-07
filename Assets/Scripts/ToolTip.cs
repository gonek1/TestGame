using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTip : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [TextArea()] [SerializeField] string des;
    public void OnPointerEnter(PointerEventData eventData)
    {
        //ToolTipManager.instance.SetPos(this.transform, des);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //ToolTipManager.instance.UnSetPos();
    }
}
