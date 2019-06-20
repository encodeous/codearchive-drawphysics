using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets;
using UnityEngine;

public class BallWin : MonoBehaviour
{
    public bool enabled = false;
    public double time = 0;
    Vector3 lastLoc = new Vector3();
    Queue<Vector3> average = new Queue<Vector3>(10);
    void Update()
    {
        
        if (enabled && mean() < 0.1 )
        {
            time += Time.deltaTime;
            if (time>2)
            {
                Retry();
            }
        }
        else
        {
            time = 0;
        }
        lastLoc = gameObject.transform.position;
        if (average.Count == 10)
            average.Dequeue();
        average.Enqueue(lastLoc);
        
    }

    float mean()
    {
        float total = 0;
        foreach (Vector3 v in average)
        {
            total += v.magnitude;
        }

        return total / average.Count;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        ControllerScript.win();
        if (col.gameObject.tag == "Cup")
        {
            Destroy(gameObject);
        }
    }

    public void Retry()
    {
        Controller.UnloadLevel();
        Controller.LoadLevel();
    }
}
