using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    private Area currentArea;
    private Area prevArea;

    public event Action<Area, Area/*prev, new*/> OnAreaChangeEvent;

    public void ChangeArea(Area newArea)
    {
        if(currentArea != null)
        {
            currentArea.ExitArea();
            prevArea = currentArea;
        }
        currentArea = newArea;
        currentArea.EnterArea();

        OnAreaChangeEvent?.Invoke(prevArea, currentArea);
    }
}