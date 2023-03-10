using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class UIController : MonoBehaviour
{
    VisualElement root;

    public List<Faction> factions;

    void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        InitializeBadges();

        new DropdownController(root, factions);
    }

    void InitializeBadges()
    {
        string[] romanNum = { "I", "II", "III", "IV", "V", "VI" };
        int index = 0;
        root
            .Query("PanelBadges")
            .Descendents<VisualElement>()
            .Name("LabelLevel")
            .ForEach(elem => (elem as Label).text = romanNum[index++]);
    }
}
