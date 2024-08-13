using UnityEngine;

public interface IHold
{
    public SocketType SocketType { get; set; }
    public GameObject Body { get; set; }

    public void Hold(Socket holdSocket, CharacterHolder holder);
    public void Unhold();
}