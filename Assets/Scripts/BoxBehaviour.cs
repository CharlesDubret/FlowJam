using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    private BoxColor boxColor = BoxColor.None;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            BoxBehavior script = collision.collider.GetComponent<BoxBehavior>();

            if(script != null && script.GetInstanceID() > GetInstanceID() )
            {
                Debug.Log("9A TAPE");
            }
        }
    }

    public void setBoxColor(BoxColor boxColor)
    {
        Debug.Log("Set Color");
        this.boxColor = boxColor;
    }

    public BoxColor getBoxColor()
    {
        Debug.Log("get Color");

        return this.boxColor;
    }
}

public enum BoxColor
{
    None = 0, 
    Orange = 1,
    Purple = 2,
    Blue = 3,
    Green = 4,
}
