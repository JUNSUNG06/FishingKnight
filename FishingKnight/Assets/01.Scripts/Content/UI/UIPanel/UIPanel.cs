using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : UIObject
{
    public bool CanHideByInput;

    public override void Show()
    {
        base.Show();

        Manager.Instance.UI.ShowPanel(this);
    }

    public virtual void OnlyShow()
    {
        base.Show();
    }
}
