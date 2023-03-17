using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ListController
{
    VisualElement root;

    ListView list;

    List<ListItem> listItems;

    ListItem chosenItem;

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

        list.selectionChanged += (elem) => OnSelectionChanged(elem);
    }

    private void OnSelectionChanged(IEnumerable<object> elem)
    {
        chosenItem = elem.First() as ListItem;
        UpdateDetails();
    }

    
    private void UpdateDetails()
    {
        VisualElement detail_img = root.Q<VisualElement>("DetailImg");
        Sprite iconImg = Resources.Load<Sprite>("img/" + chosenItem.itemIconPath);
        detail_img.style.backgroundImage = new StyleBackground(iconImg);

        Debug.Log(detail_img.name);

        Label fraction_label = root.Q<Label>("DetailName");
        fraction_label.text = chosenItem.itemName;

        Label fraction_score = root.Q<Label>("DetailsScore");
        fraction_score.text = "Score: " + chosenItem.score;

        VisualElement score_img = root.Q<VisualElement>("DetailsScoreImg");
        Sprite score_sprite = Resources.Load<Sprite>("img/" + chosenItem.itemIconPath2);
        score_img.style.backgroundImage = new StyleBackground(score_sprite);

        Label reward_label = root.Q<Label>("DetailsReward");
        reward_label.text = "Reward: " + chosenItem.reward;

    }
}
