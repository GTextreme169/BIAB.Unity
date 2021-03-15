using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Physics 2D/CurvedCollider")]

[RequireComponent(typeof(EdgeCollider2D))]
public class CurvedCollider : MonoBehaviour
{
    public bool InvertX = false;
    public bool InvertY = false;
    public bool filled = false;
    public int smoothness = 32;
    private List<Vector2> points;
    private EdgeCollider2D edgeCollider2D;

    void Awake()
    {
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
        Apply();
    }
    public void Apply()
    {
        for (int s = 0; s <= smoothness; s++)
        {
            float x = s / (smoothness * 1f);
            points.Add(new Vector2((InvertY ? x : 1-x), (InvertX ? Mathf.Sqrt(1 - (x * x)) : 1 - Mathf.Sqrt(1 - (x * x)))));
        }

        if (filled)
        {
            // Invert and Inner (1,0)(0,0)
            // Inner (0,0)(1,0)
            // Invert Outer
            points.Add(new Vector2((InvertY ? 1 : 0), (InvertX ? 1 : 0)));
            points.Add(new Vector2((InvertY ? 0 : 1), (InvertX ? 1 : 0)));
            //
            //
        }
        edgeCollider2D.points = points.ToArray();
    }
}
