﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPointHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.7f);
        // transform.localPosition = new Vector3(0, 0.0f, 0);
    }
}
