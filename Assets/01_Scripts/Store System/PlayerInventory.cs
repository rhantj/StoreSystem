using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : InventoryBase
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI goldText;
    int gold = 1000;

    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldText.text = gold.ToString();
        }
    }

    private void Start()
    {
        Gold = gold;
        actionBtn.onClick.AddListener(OnSellClicked);
    }

    void OnSellClicked()
    {
        if (!selectedItem || selectedItem.count <= 0)
        {
            StartCoroutine(ButtonClickAction(false));
            return;
        }

        if (selectedItem.count > 0)
        {
            selectedItem.count--;
            otherInv.AddItem(selectedItem.item);
            Gold += selectedItem.item.d_Price;
        }
         
        if (selectedItem.count <= 0)
        {
            selectedItem.Clear();
        }

        StartCoroutine(ButtonClickAction(true));
        UpdateUI();
    }
}