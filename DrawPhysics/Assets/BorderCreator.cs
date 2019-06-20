using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCreator : MonoBehaviour
{
    public Camera camera;
    public bool noLeft;
    public bool noRight;
    public bool noTop;
    public bool noBottom;

    void Start()
    {
        float x = camera.pixelWidth;
        float y = camera.pixelHeight;
        var offsetx = 2.5f;
        var offsety = 2.5f;
        if (!noLeft)
            addWall(5f, 1000, new Vector2(-x / 2, 0), new Vector2(-offsetx, 0)); // left
        if (!noRight)
            addWall(5f, 1000, new Vector2(x / 2, 0), new Vector2(+offsetx, 0)); // right
        if (!noTop)
            addWall(1000, 5f, new Vector2(0, y / 2), new Vector2(0, +offsety)); // top
        if (!noBottom)
            addWall(1000, 5f, new Vector2(0, -y / 2), new Vector2(0, -offsety)); // bottom

    }

    void addWall(float width, float height, Vector2 pos, Vector2 offset)
    {
        float x = camera.pixelWidth;
        float y = camera.pixelHeight;
        pos.x = pos.x + x / 2;
        pos.y = pos.y + y / 2;
        GameObject Wall = new GameObject("Wall");
        Wall.transform.position = (Vector2)camera.ScreenToWorldPoint(pos) + offset;
        Wall.AddComponent<BoxCollider2D>();
        var a = Wall.GetComponent<BoxCollider2D>();
        a.size = new Vector2(width, height);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
