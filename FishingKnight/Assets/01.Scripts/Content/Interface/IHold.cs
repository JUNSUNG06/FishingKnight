public interface IHold
{
    public SocketType SocketType { get; set; }

    public void Hold(Socket holdSocket);
    public void Unhold();
}