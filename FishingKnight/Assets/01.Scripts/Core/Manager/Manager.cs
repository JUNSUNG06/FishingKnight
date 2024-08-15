public static class Manager
{
    public static UIManager UI { get; private set; }

    static Manager()
    {
        UI = new UIManager();
    }
}
