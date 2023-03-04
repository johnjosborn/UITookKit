using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Button_Screen : MonoBehaviour
{
    //Button
    VisualElement box;
    Button myButton;

    //Text
    Label label;


    void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        box = root.Q("Box");
        myButton = root.Q<Button>("MyButton");

        myButton.clicked += OnButtonClicked;

        label = root.Q<Label>("MyLabel");
    }

    void OnButtonClicked()
    {
        int randomWidth = UnityEngine.Random.Range(50,300);
        box.style.width = randomWidth;
        int randomHeight = UnityEngine.Random.Range(50,300);
        box.style.height = randomHeight;

        label.text = "Button clicked";

    }
}
