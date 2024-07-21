using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        this.gameObject.SetActive(false);
    }
}
