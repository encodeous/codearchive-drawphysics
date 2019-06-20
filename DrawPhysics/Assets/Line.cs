using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public PolygonCollider2D collider;

    public List<Vector2> points = new List<Vector2>();
    public List<Vector3> PointsCache = new List<Vector3>();
    public bool Drawn;

    public LineRenderer InkRenderer = new LineRenderer();

    public MeshFilter mf;

    public Material InkMaterial;

    // Start is called before the first frame update
    private void Start()
    {
        mf = gameObject.AddComponent<MeshFilter>();
        InkMaterial = new Material(Shader.Find("Specular")) { color = ControllerScript.currentLineColor };
        InkRenderer = gameObject.AddComponent<LineRenderer>();
        InkRenderer.material = InkMaterial;
        InkRenderer.endColor = Color.black;
        InkRenderer.startWidth = 0.06f;
        InkRenderer.endWidth = 0.06f;
        InkRenderer.useWorldSpace = false;
    }

    // Update is called once per frame
    private void Update()
    {
    }


    /// <summary>
    ///     Creates a Polygon Collider from a series a points
    /// </summary>
    /// <param name="p">Points</param>
    /// <param name="thickness">How thick the line is</param>
    /// <returns></returns>
    public void CreateColliderFromPoints(PolygonCollider2D col, Vector2 thickness)
    {
        var offsetPoints = new List<Vector2>();
        for (int i = 0; i< points.Capacity; i++)
        {
            if (points.Count > i) offsetPoints.Add(points[i]+ thickness);
        }
        for (int i = points.Capacity-1; i >=0; i--)
        {
            if (points.Count > i) offsetPoints.Add(points[i] - thickness);
        }
        col.points = offsetPoints.ToArray();
    }

    public void CreateRigidBody2D()
    {
        var a = gameObject.AddComponent<Rigidbody2D>();
        a.useAutoMass = true;
    }
}