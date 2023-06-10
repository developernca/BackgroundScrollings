using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOnlyMoveScroller : MonoBehaviour
{
    public GameObject[] bg1;
    public GameObject[] bg2;
    public GameObject[] bg3;
    public float[] speedList;

    private List<GameObject[]> parallaxList;
    private Camera mainCam;
    private float spriteWidth;

    private void Awake()
    {
        mainCam = Camera.main;
        parallaxList = new List<GameObject[]>();
        parallaxList.Add(bg1);
        parallaxList.Add(bg2);
        parallaxList.Add(bg3);
        spriteWidth = bg1[0].GetComponent<SpriteRenderer>().bounds.size.x;
        print(spriteWidth);
    }

    private void Update()
    {
        int speedIndex = 0;
        foreach (GameObject[] objArr in parallaxList)
        {
            float scrollSpeed = speedList[speedIndex];
            foreach (GameObject obj in objArr)
            {
                float x = obj.transform.position.x - (scrollSpeed * Time.deltaTime);
                obj.transform.position = new Vector3(x, obj.transform.position.y, obj.transform.position.z);
            }
            ++speedIndex;
        }

        foreach (GameObject[] objArr in parallaxList)
        {
            int len = objArr.Length;
            for (int i = 0; i < len; i++)
            {
                if (objArr[i].transform.position.x < mainCam.transform.position.x - spriteWidth)
                {
                    int lastSpriteIndex = (i == 0) ? len - 1 : i - 1;
                    objArr[i].transform.position = new Vector3(objArr[lastSpriteIndex].transform.position.x + spriteWidth, objArr[i].transform.position.y, objArr[i].transform.position.z);
                    break;
                }
            }
        }
    }
}
