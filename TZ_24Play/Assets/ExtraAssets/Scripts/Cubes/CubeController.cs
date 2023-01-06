using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CubeController Instance;
    public List<GameObject> cubeList = new List<GameObject>();
    public int index;

    private void Awake()
    {
        index = 0;
        if (Instance == null)
            Instance = this;
    }
}
