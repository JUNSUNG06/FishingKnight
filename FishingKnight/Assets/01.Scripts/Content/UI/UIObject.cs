using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    private RectTransform rect;
    public RectTransform Rect => rect;

    protected bool isActive;
    public bool IsActive => isActive;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public virtual void Initialize()
    {
        
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);

        isActive = true;
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);

        isActive = false;
    }
}
