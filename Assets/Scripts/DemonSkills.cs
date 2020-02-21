using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSkills : MonoBehaviour
{
    public static DemonSkills instance;
    public Transform Player;
    private int durationDemonForm;
    public int DurationDemonForm { get => durationDemonForm; set => durationDemonForm = value; }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActiveDemonForm()
    {

    }
    public void EnableDemonForm()
    {

    }
    public void ReturnToPlayer()
    {
        transform.position = Player.position;
    }
}
