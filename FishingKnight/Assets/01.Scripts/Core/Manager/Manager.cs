public static class Manager
{
    public static UIManager UI { get; private set; }
    public static CameraManager Camera { get; private set; }

    static Manager()
    {
        UI = new UIManager();
        Camera = new CameraManager();
    }
}
