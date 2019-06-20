using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerScript : MonoBehaviour
{
    public Line currentLine;

    // Start is called before the first frame update
    public GameObject o;



    // Update is called once per frame
    private int frames = 0;
    private void Update()
    {
        frames++;

        var rb2d = GetComponent<Rigidbody2D>();
        var col = o.GetComponent<PolygonCollider2D>();
        Vector2 mousePosition = rb2d.transform.position;
        if (!currentLine.points.Contains(mousePosition))
        {
            currentLine.points.Add(mousePosition);
        }

        if (!currentLine.PointsCache.Contains(mousePosition))
        {
            currentLine.PointsCache.Add(mousePosition);
        }

        if (currentLine.InkRenderer != null)
        {
            currentLine.InkRenderer.positionCount = currentLine.PointsCache.Count;
            currentLine.InkRenderer.SetPosition(currentLine.points.Count - 1,
                currentLine.points[currentLine.points.Count - 1]);
        }

        if (currentLine.mf != null) currentLine.mf.mesh.vertices = currentLine.PointsCache.ToArray();
    }

    public void Stop()
    {
        ControllerScript.lines.Add(o);
        if (currentLine.points.Count >2)
        {
            var col = o.GetComponent<PolygonCollider2D>();
            currentLine.CreateColliderFromPoints(col, new Vector2(0.03f, 0.03f));
            col.enabled = true;
            currentLine.CreateRigidBody2D();
        }

        if (GameObject.Find("The Cup").GetComponent<Rigidbody2D>() == null)
        {
            var a = GameObject.Find("The Cup").AddComponent<Rigidbody2D>();
            a.useAutoMass = true;
        }
        if (GameObject.Find("Ball").GetComponent<Rigidbody2D>() == null)
        {
            var b = GameObject.Find("Ball").AddComponent<Rigidbody2D>();
            b.useAutoMass = true;
            GameObject.Find("Ball").GetComponent<BallWin>().enabled = true;
        }

        var objects = GameObject.FindGameObjectsWithTag("Dynamic");
        foreach (GameObject obj in objects)
        {
            var a = obj.GetComponent<Rigidbody2D>();
            a.isKinematic = false;
            a.useAutoMass = true;
        }
    }
}
