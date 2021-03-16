using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeTrialUI : MonoBehaviour
{
    [SerializeField] private float timePassed = 120;
    [SerializeField] private Text timeUI;

    // Start is called before the first frame update
    private void Start()
    {
        timeUI = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        timePassed -= Time.deltaTime;
        if (timePassed <= 0.5)
        {
            SceneManager.LoadScene("YouLoseMenu");
        }
        UpdateText(timePassed);
    }

    private void UpdateText(float timePassed)
    {
        timeUI.text = $"{timePassed.ToString("F2")}s";
    }
}
