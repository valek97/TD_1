﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Camera camera;
    TowerPlace currTP;



    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>(); 
    }

    // Update is called once per frame
    void Update()
    {
        

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "TowerPlace")
        {
            bool isMouseDown = Input.GetMouseButtonDown(0);
            bool isMouseUp = Input.GetMouseButtonUp(0);

            TowerPlace tp = hit.collider.gameObject.GetComponent<TowerPlace>();
            if (isMouseDown || isMouseUp)
            {
            
                    if (isMouseDown)
                    {
                        tp.MouseDown();
                    }
                    else if (isMouseUp)
                    {
                        tp.MouseUp();
                    }


                
            }
            else 
            {
                if (currTP != tp)
                {
                    if (currTP != null)
                        currTP.MouseLeave();
                }

                tp.MouseEnter();
                currTP = tp;
            }
        }
        else
        {
            if (currTP != null)
                currTP.MouseLeave();

            currTP = null;
        }
    }
}
