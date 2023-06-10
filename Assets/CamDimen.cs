using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDimen
{
    private float camFullWidth;
    private float camHalfWidth;
    private float camFullHeight;
    private float camHalfHeight;

    private void SetCamDimen()
    {
        camHalfHeight = Camera.main.orthographicSize;
        camFullHeight = camHalfHeight * 2f;
        camHalfWidth = Camera.main.aspect * camHalfHeight;
        camFullWidth = camHalfWidth * 2f;
        // print($"Height : {camHalfHeight} - {camFullHeight}");
        // print($"Width : {camHalfWidth} - {camFullWidth}");
    }
}
