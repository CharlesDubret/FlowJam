using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivalBehavior : MonoBehaviour
{
    [SerializeField] private GameManager _gm;

    public BoxColor arrivalColor;

    public int requiredBox;

    private int boxCount = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box" && other.GetComponent<BoxBehavior>().getBoxColor() == arrivalColor)
        {
            boxCount++;
            if (boxCount >= requiredBox)
            {
                _gm.EndGame();
            }
            else if (boxCount == requiredBox)
            {
                _gm.addFinishedArrival();
            }
        } 
        else if (other.tag == "Box" && other.GetComponent<BoxBehavior>().getBoxColor() != arrivalColor)
        {
            _gm.EndGame();
        }
    }
}
