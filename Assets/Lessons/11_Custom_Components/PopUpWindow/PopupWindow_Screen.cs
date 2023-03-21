using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupWindow_Screen : MonoBehaviour
{

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        PopupWindow popup = new PopupWindow();
        popup.Prompt = "Oh lawd.";

        root.Add(popup);

    }

}
