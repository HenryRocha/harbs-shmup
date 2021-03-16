using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBetweenScenes : MonoBehaviour
{
    [SerializeField] private string tagName;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tagName);
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {

            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
