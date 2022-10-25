using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
        //get mouse postion pixel vector
        Vector2 mousePos = Input.mousePosition;

        //Use the camera to convert pixel postion to world position
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        //Set our position to the mouse world position
        transform.right = (Vector3)mousePos - transform.position;
    }
}
