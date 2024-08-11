using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] CharacterHealth a;
    void Start()
    {
        Debug.Log(a as EntityComponent != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
