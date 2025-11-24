using System.Collections.Generic;
using UnityEngine;

public class StoreInventory : InventoryBase
{
    [Header("Store items")]
    [SerializeField] List<ItemData> storeItems;

    private void OnEnable()
    {
        SetItems();
    }

    private void OnDisable()
    {
        foreach(var slot in slots)
        {
            slot.Clear();
        }
    }

    private void Start()
    {
        actionBtn.onClick.AddListener(OnPurchaseClicked);
    }

    void SetItems()
    {
        var itemIdx = Random.Range(0, storeItems.Count);
        var used = new List<int>();

        for (int i = 0; i < 4; ++i)
        {
            if (used.Contains(itemIdx))
            {
                itemIdx = Random.Range(0, storeItems.Count);
            }
            SetStoreItem(storeItems[itemIdx]);
            used.Add(itemIdx);
        }
    }

    void SetStoreItem(ItemData data)
    {
        if (data.canStack)
        {
            ItemSlot slot = GetItemSlot(data);
            if (slot != null)
            {
                slot.count += data.d_Count;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.count = data.d_Count;

            UpdateUI();
            return;
        }
    }

    void OnPurchaseClicked()
    {
        var playerinv = otherInv.GetComponent<PlayerInventory>();
        if (!selectedItem || selectedItem.count <= 0 || playerinv.Gold <= 0)
        {
            StartCoroutine(ButtonClickAction(false));
            return;
        }

        if (selectedItem.count > 0)
        {
            selectedItem.count--;
            otherInv.AddItem(selectedItem.item);
            playerinv.Gold -= selectedItem.item.d_Price;
        }

        if (selectedItem.count <= 0)
        {
            selectedItem.Clear();
        }

        StartCoroutine(ButtonClickAction(true));
        UpdateUI();
    }
}