using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SliderScript : MonoBehaviour
{
    VisualElement box;
    Slider slider;
    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        box = root.Q("SliderBox");
        slider = root.Q<Slider>("MySlider");

        slider.RegisterCallback<ChangeEvent<float>>(OnSliderChanged);
    }

    void OnSliderChanged(ChangeEvent<float> evt)
    {
        box.style.width = evt.newValue;
        box.style.height = evt.newValue;
    }
}
