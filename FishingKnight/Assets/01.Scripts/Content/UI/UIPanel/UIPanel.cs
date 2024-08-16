using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UIObject
{
    public override void Show()
    {
        base.Show();

        Manager.UI.ShowPanel(this);
    }
}
