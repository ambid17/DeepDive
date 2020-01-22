using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.backgroundColor = ColorForDepth(transform.position.y);
    }

    private Color ColorForDepth(float depth)
    {

        Debug.Log("Finding Color for depth: " + depth);

        Color defaultColor = new Color(60f / 255f, 114f / 255f, 161f / 255f);

        switch (Mathf.FloorToInt(Mathf.Abs(depth)))
        {
            case int i when (i >= 20 && i <= 80):
                return new Color(0, 0, 1);
            case int i when (i > 80 && i < 160):
                return new Color(0, 1, 0);
            case int n when (n >= 160):
                return new Color(1, 0, 0);

            default:
                return defaultColor;
        }
    }
}
