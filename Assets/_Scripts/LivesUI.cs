using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private PlayerController player = null;

    // Reference to the Text object, which is used to display the lives on the screen.
    private Text livesTextUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the reference to the Text component.
        livesTextUI = GetComponent<Text>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Update the display.
        UpdateText(player.lifes);
    }

    private void UpdateText(int newLives)
    {
        // Update the UI text.
        livesTextUI.text = $"Lives: {newLives}";
    }
}
