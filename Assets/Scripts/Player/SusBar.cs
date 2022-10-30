using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SusBar : MonoBehaviour
{
    Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    public void SetMaxSus(int sus) {
        slider.maxValue = sus;
        slider.value = slider.minValue;
    }

    public void SetSus(int sus) {
        slider.value = sus;
    }

    public void AddSus(int sus) {
        slider.value += sus;
    }

    public void RemoveSus(int sus) {
        slider.value -= sus;
    }
}
