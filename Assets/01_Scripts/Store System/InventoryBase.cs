using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBase : MonoBehaviour
{
    [SerializeField] protected ItemSlot[] slots;
    [SerializeField] protected Transform slotPanel;
    [SerializeField] protected Button actionBtn;
    [SerializeField] protected InventoryBase otherInv;

    protected ItemSlot selectedItem;

    private void Awake()
    {
        slots = new ItemSlot[slotPanel.childCount];

        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].idx = i;
            slots[i].inventory = this;

            ClearSelectedItemWindow();
        }
        UpdateUI();
    }

    protected void ClearSelectedItemWindow()
    {
        selectedItem = null;
    }

    public void SelectItem(int idx)
    {
        if (slots[idx].item == null) return;

        selectedItem = slots[idx];
    }

    public virtual void AddItem(ItemData data)
    {
        if (data.canStack)
        {
            ItemSlot slot = GetItemSlot(data);
            if (slot != null)
            {
                slot.count++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.count++;

            UpdateUI();
            return;
        }
    }

    protected ItemSlot GetItemSlot(ItemData data)
    {
        if (data == null) return null;

        for (int i = 0; i < slots.Length; ++i)
        {
            var item = slots[i].item;
            if (item == null) continue;

            if (ReferenceEquals(item, data)) return slots[i];
        }

        return null;
    }

    protected ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].item == null)
                return slots[i];
        }

        return null;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; ++i)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    protected IEnumerator ButtonClickAction(bool action)
    {
        Color firstColor = actionBtn.image.color;
        Color buttonColor = action ? Color.green : Color.red;

        actionBtn.image.color = buttonColor;
        float elapsedTime = 0f;
        while (elapsedTime < 0.1f)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        actionBtn.image.color = firstColor;
    }
}