using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualElement root;

    ListView list;

    List<ListItem> listItems;

    public ListController(VisualElement root, List<ListItem> items)
    {
        this.root = root;
        this.listItems = items;

        CreateList();
    }

    void CreateList()
    {
        list = root.Q<ListView>("List");
        VisualTreeAsset listItemAsset =
            Resources.Load<VisualTreeAsset>("ListItem");

        list.makeItem = () => listItemAsset.Instantiate();
        list.bindItem = (visualElement, index) =>
        {
            VisualElement factionIcon =
                visualElement.Q<VisualElement>("FractionIcon");
            VisualElement uselessIcon =
                visualElement.Q<VisualElement>("OtherIcon");
            Label someName = visualElement.Q<Label>("ListItemName");
            Label score = visualElement.Q<Label>("Score");
            Label reward = visualElement.Q<Label>("Reward");

            ListItem currentItem = listItems[index];

            Sprite iconImg =
                Resources.Load<Sprite>("img/" + currentItem.itemIconPath);
            factionIcon.style.backgroundImage = new StyleBackground(iconImg);

            Sprite iconImg2 =
                Resources.Load<Sprite>("img/" + currentItem.itemIconPath2);
            uselessIcon.style.backgroundImage = new StyleBackground(iconImg2);

            someName.text = currentItem.itemName;
            score.text = currentItem.score;
            reward.text = "Reward: " + currentItem.reward;
        };

        list.itemsSource = listItems;
        list.fixedItemHeight = 60;
    }
}
