using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTest : MonoBehaviour
{
    public  Transform player;
    public Vector3 offset;
    float xRand;
    float yRand;
    PlayerState state;
    [Range(0,1)]public float smoothing;
    void Update()
    {
        if (state == PlayerState.Idle)
        {
            GoAroundPlayer();
        }
        else if (state == PlayerState.Running)
        {
            FollowPlayer();
        }
        if (Controller.instance.VerInp != 0 || Controller.instance.HorInp != 0)
        {
            state = PlayerState.Running;
        }
        else
        {
            state = PlayerState.Idle;
        }
    }
    private void Start()
    {
        state = PlayerState.Idle;
    }

    private void FollowPlayer()
    {
        
        transform.position = Vector2.Lerp(transform.position,
            player.position + offset , smoothing * Time.deltaTime);
    }
    private void GoAroundPlayer()
    {
        float step = 10 * Time.deltaTime;
        if (Vector2.Distance(transform.position, player.position) > 1)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        }
        else
        {
            xRand = Random.Range(-2f, 2f);
            yRand = Random.Range(-2f, 2f);
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(xRand, yRand), step/10);
            // transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(xRand, yRand), smoothing * Time.deltaTime);
        }
    }


    enum PlayerState
    {
        Idle,
        Running
    }
}
