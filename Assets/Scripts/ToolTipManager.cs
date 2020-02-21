using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTipManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector2 offset;
    [SerializeField] TextMeshProUGUI texttooltip;
    [SerializeField] RectTransform backgroundTransform;
    public static ToolTipManager instance;
    void Awake()
    {
        instance = this;
    }
    public void ShowToolTip(string text)
    {
        gameObject.SetActive(true);
        texttooltip.text = text;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(texttooltip.preferredWidth + textPaddingSize * 2, texttooltip.preferredHeight + textPaddingSize * 2);
        backgroundTransform.sizeDelta = backgroundSize;
    }
    public static void ShowToolTip_static(string text)
    {
       instance.ShowToolTip(text);
    }
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }
    public static void HideToolTip_static()
    {
        instance.HideToolTip();
    }
    void Update()
    {
        Vector2 localpoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out localpoint);
        transform.position = localpoint;
    }
    void Start()
    {
        
    }
}
