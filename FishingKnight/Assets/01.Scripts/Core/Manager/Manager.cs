using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Instance => instance;

    public UIManager UI { get; private set; }
    public CameraManager Camera { get; private set; }
    public AreaManager Area { get; private set; }

    private void Awake()
    {
        instance = this;

        UI = gameObject.AddComponent<UIManager>();
        Camera = gameObject.AddComponent<CameraManager>();
        Area = gameObject.AddComponent<AreaManager>();
    }
}
