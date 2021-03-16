using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private float timePassed = 0;
    [SerializeField] private Text timeUI;

    // Start is called before the first frame update
    private void Start()
    {
        timePassed = 0;
        timeUI = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        timePassed += Time.deltaTime;
        UpdateText(timePassed);
    }

    private void UpdateText(float timePassed)
    {
        timeUI.text = $"{timePassed.ToString("F2")}s";
    }
}
