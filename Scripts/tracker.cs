using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracker : MonoBehaviour
{

    public static GameObject cam;

    public static Transform GetTransform()
    {
        return cam.transform;
    }
}
