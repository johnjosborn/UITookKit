using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TemplateScripts : MonoBehaviour
{
    VisualElement container;
    VisualElement item;
    VisualElement item2;

    void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        container = root.Q("Container");
        item = new VisualElement();
        item.style.width = 100;
        item.style.height = 100;
        item.style.backgroundColor = Color.yellow;
        item2 = new VisualElement();
        item2.style.width = 100;
        item2.style.height = 100;
        item2.style.backgroundColor = Color.yellow;

        container.Add(item);
        container.Add(item2);

    }
}
