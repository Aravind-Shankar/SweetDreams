using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SusBar : MonoBehaviour
{
    Slider slider;
    public Image fill;
    public Gradient gradient;

    PauseMenuToggle menu;

    private void Awake() {
        slider = GetComponent<Slider>();
        menu = FindObjectOfType<PauseMenuToggle>();
    }

    private void Update() {
        if (slider.value == slider.maxValue) {
            menu.Lose();
        }
    }

    public void SetMaxSus(float sus) {
        slider.maxValue = sus;
        slider.value = slider.minValue;
    }

    public void SetSus(float sus) {
        slider.value = sus;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void AddSus(float sus) {
        SetSus(slider.value + sus);
    }

    public void RemoveSus(float sus) {
        SetSus(slider.value - sus);
    }
}
