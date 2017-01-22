using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class see : MonoBehaviour
{
    void Start()
    {
        WebCamTexture webcamTexture = new WebCamTexture(1280, 720, 25);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }

    private void Update()
    {
        WebCamTexture wct = new WebCamTexture(1280, 720, 25);
        if (wct.width < 100)
        {
            Debug.Log("Still waiting another frame for correct info...");
            return;
        }

        // change as user rotates iPhone or Android:

        int cwNeeded = wct.videoRotationAngle;
        // Unity helpfully returns the _clockwise_ twist needed
        // guess nobody at Unity noticed their product works in counterclockwise:
        int ccwNeeded = -cwNeeded;

        // IF the image needs to be mirrored, it seems that it
        // ALSO needs to be spun. Strange: but true.
        if (wct.videoVerticallyMirrored) ccwNeeded += 180;
    }
}