using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropdownController
{
    VisualElement root;

    Faction currentFaction = null;

    // Contructor
    public DropdownController(VisualElement root, List<Faction> factions)
    {
        this.root = root;

        VisualElement container = root.Q("DropdownContainer");

        PopupField<Faction> dropDown = new PopupField<Faction>();

        dropDown.choices = factions;
        dropDown.value = factions[0];
        currentFaction = factions[0];

        dropDown.formatListItemCallback = (elem) => elem.factionName;
        dropDown.formatSelectedValueCallback = (elem) => elem.factionName;

        dropDown.RegisterCallback<ChangeEvent<Faction>> (OnFactionSelected);

        container.Add (dropDown);

        UpdateUI();
    }

    void OnFactionSelected(ChangeEvent<Faction> evt)
    {
        currentFaction = evt.newValue;
        UpdateUI();
    }

    private void UpdateUI()
    {
        VisualElement characterElem = root.Q<VisualElement>("Character");
        Sprite charImg =
            Resources.Load<Sprite>(currentFaction.characterImgPath);
        characterElem.style.backgroundImage = new StyleBackground(charImg);

        Label factionLabel = root.Q<Label>("FactionName");
        factionLabel.text = currentFaction.factionName;

        Label factionMotto = root.Q<Label>("FactionMotto");
        factionMotto.text = currentFaction.factionMotto;

        VisualElement factionIconElem = root.Q<VisualElement>("PanelIcon");
        Sprite factionIcon =
            Resources.Load<Sprite>(currentFaction.iconImgPath);
        factionIconElem.style.backgroundImage = new StyleBackground(factionIcon);

        VisualElement factionImgElem = root.Q<VisualElement>("PanelFaction");
        Sprite factionImg =
            Resources.Load<Sprite>(currentFaction.factionImgPath);
        factionImgElem.style.backgroundImage = new StyleBackground(factionImg);
    }
}
