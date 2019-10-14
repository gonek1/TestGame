using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Skill
{
    void Use();
     string Name { get; set; }
     Sprite UiIcon { get; set; }
    void AddToSlot(int index);
}
