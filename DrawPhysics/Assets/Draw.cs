using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Draw : MonoBehaviour
{
    private GameObject CursorTracker;
    private void Start()
    {

    }

    private int count = 0;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (CursorTracker == null)
            {
                CursorTracker = new GameObject("CursorTracker");
                var col = CursorTracker.AddComponent<CircleCollider2D>();
                col.radius = 0.06f;
                var rigid = CursorTracker.AddComponent<Rigidbody2D>();
                rigid.mass = 0.0001f;
                rigid.angularDrag = 0;
                rigid.gravityScale = 0;
                var t = CursorTracker.AddComponent<TrackerScript>();
                CursorTracker.transform.position = cursorPosition;
                rigid.transform.position = cursorPosition;
                t.o = new GameObject("Line");
                t.currentLine = t.o.AddComponent<Line>();
                var a = t.o.AddComponent<PolygonCollider2D>();
                a.enabled = false;
            }
            var rigidBody = CursorTracker.GetComponent<Rigidbody2D>();
            
            
            Vector2 mousePosition = rigidBody.transform.position;
            var tracker = CursorTracker.GetComponent<TrackerScript>();
            if (count == 0)
            {
                CursorTracker.transform.position = cursorPosition;
                rigidBody.transform.position = cursorPosition;
                mousePosition = rigidBody.transform.position;
                rigidBody.simulated = true;
            }
            if (count > 1)
            {
                
                var heading = cursorPosition - mousePosition;
                rigidBody.velocity = heading*7;
            }

            count++;
        }

        if (Input.GetMouseButtonUp(0))
        {
            count = 0;
            var s = CursorTracker.GetComponent<TrackerScript>();
            s.Stop();
            Destroy(CursorTracker);
            CursorTracker = null;
        }
    }
}