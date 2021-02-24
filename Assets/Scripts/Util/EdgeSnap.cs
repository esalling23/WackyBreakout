using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeSnap : MonoBehaviour
{
    EdgeCollider2D edge;
    // Start is called before the first frame update
    void Start()
    {
        edge = GetComponent<EdgeCollider2D>();

        Vector2[] tempPoints = new Vector2[4];

        // Should have 4 points: bottom left, top left, top right, bottom right
        tempPoints[0] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom);
        tempPoints[1] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
        tempPoints[2] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
        tempPoints[3] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom);

        edge.points = tempPoints;
    }
}
