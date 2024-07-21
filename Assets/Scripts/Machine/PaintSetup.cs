using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PaintSetup : ActivitySetup
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private GameObject go;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject instantiationParent;

    [SerializeField] private GameObject gui;

    private Paint _activity;
    private List<GameObject> instantiated = new List<GameObject>();
    private Image targetImage;
    private List<Image> colorHolders = new List<Image>();

    public override void Initialize(Activity activity)
    {
        _activity = (Paint)activity;
        title.text = "Painter";
        AddButton();
        IsReady = false;
        gameObject.SetActive(true);
        gui.SetActive(true);
    }
    
    public void SetColor(Image image)
    {
        targetImage.color = image.color;
    }
    
    public void SetTargetImage(Image image)
    {
        targetImage = image;
        ShowColorPicker();
    }

    public void Ready()
    {
        if (colorHolders.Count < 1) return;
        foreach (Image image in colorHolders)
        {
            if (image.color == Color.white)
                return;
        }
        List<Color> colorsOrder = new List<Color>();
        foreach (Image image in colorHolders)
            colorsOrder.Add(image.color);
        _activity.SetSelectedColorsOrder(colorsOrder);
        gui.SetActive(false);
        gameObject.SetActive(false);
        IsReady = true;
        SendReady.Invoke();
    }

    public void AddButton()
    {
        if (instantiated.Count >= 10) return;
        GameObject instance = Instantiate(prefab, instantiationParent.transform);
        instance.GetComponentInChildren<Button>().onClick.AddListener(delegate { SetTargetImage(instance.GetComponentInChildren<Image>()); });
        instantiated.Add(instance);
        colorHolders.Add(instance.GetComponent<Image>());
    }

    public void RemoveButton()
    {
        if (instantiated.Count <= 1) return;
        GameObject obj = instantiated[instantiated.Count - 1];
        instantiated.RemoveAt(instantiated.Count - 1);
        Image image = colorHolders[colorHolders.Count - 1];
        colorHolders.Remove(image);
        Destroy(obj);
    }

    private void ShowColorPicker()
    {
        go.SetActive(true);
    }
}
