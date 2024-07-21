using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SplitterSetup : ActivitySetup // 1 Flip machine = 1 splitter setup
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI value;
    [SerializeField] private int FlipEvery = 1;

    [SerializeField] private Flip _activity;

    public override void Initialize(Activity activity)
    {
        _activity = (Flip)activity;
        title.text = "Splitter";
        IsReady = false;
        gameObject.SetActive(true);
    }
    
    public void Ready()
    {
        _activity.SetFlipAfter(FlipEvery);
        IsReady = true;
        gameObject.SetActive(false);
        SendReady.Invoke();
    }

    public void AddButton()
    {
        if (FlipEvery >= 10) return;
        FlipEvery++;
        value.text = FlipEvery.ToString();
    }

    public void RemoveButton()
    {
        if (FlipEvery <= 1) return;
        FlipEvery--;
        value.text = FlipEvery.ToString();
    }
}
