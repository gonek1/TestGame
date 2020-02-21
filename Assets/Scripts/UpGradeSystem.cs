using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpGradeSystem : MonoBehaviour
{
    public static UpGradeSystem instance;
    void Awake()
    {
        instance = this;
    }
    [SerializeField] TextMeshProUGUI description;
    public void ShowDes(string des)
    {
        description.text = des;
    }
    public void ClearDes()
    {
        description.text = null;
    }
}
