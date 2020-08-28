using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Finish finish { get; private set; }

    private void Awake()
    {
        finish = this;
    }
}
