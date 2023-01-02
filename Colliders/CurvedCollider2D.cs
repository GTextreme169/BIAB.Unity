using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Physics 2D/CurvedCollider2D")]

[RequireComponent(typeof(EdgeCollider2D))]
public class CurvedCollider2D : MonoBehaviour
{
    [FormerlySerializedAs("InvertX")] public bool invertX  = false;
    [FormerlySerializedAs("InvertY")] public bool invertY = false;
    public bool filled = false;
    public int smoothness = 32;
    
    private List<Vector2> _points;
    private EdgeCollider2D _edgeCollider2D;

    void Awake()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        _points = new List<Vector2>();
        Apply();
    }
    public void Apply()
    {
        for (int s = 0; s <= smoothness; s++)
        {
            float x = s / (smoothness * 1f);
            _points.Add(new Vector2((invertY ? x : 1-x), (invertX ? Mathf.Sqrt(1 - (x * x)) : 1 - Mathf.Sqrt(1 - (x * x)))));
        }

        if (filled)
        {
            // Invert and Inner (1,0)(0,0)
            // Inner (0,0)(1,0)
            // Invert Outer
            _points.Add(new Vector2((invertY ? 1 : 0), (invertX ? 1 : 0)));
            _points.Add(new Vector2((invertY ? 0 : 1), (invertX ? 1 : 0)));
            //
            //
        }
        _edgeCollider2D.points = _points.ToArray();
    }
}
