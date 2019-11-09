using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    //Можно строить?
    bool isCanBuild = true;
    public GameObject tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Клавиша мыши нажата, курсор находится над объектом
    public void MouseDown()
    {
        if (isCanBuild)
        {
            isCanBuild = false;
            Instantiate(tower, transform.position, transform.rotation);
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
        }
    }



    //Клавиша мыши отпущена, курсор находится над объектом
    public void MouseUp()
    {
       
    }


    //Если курсор мыши оказался над объектом
    public void MouseEnter()
    {
        if (isCanBuild)
            GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    }



    //Если курсор мыши не находится над объектом
    public void MouseLeave()
    {
        if (isCanBuild)
            GetComponent<Renderer>().material.color = new Color(1, 1, 1);
    }
}
