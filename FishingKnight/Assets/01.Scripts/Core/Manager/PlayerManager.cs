using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player player;
    public Player Player => player;

    private void Awake()
    {
        GameObject playerObj = new GameObject("Player");
        playerObj.transform.parent = transform;
        player = playerObj.AddComponent<Player>();
    }
}
