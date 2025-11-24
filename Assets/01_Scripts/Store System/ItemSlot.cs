using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;
    public InventoryBase inventory;
    public Button button;
    public Image icon;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI priceText;

    public int idx;
    public int count;

    private void OnEnable()
    {
        if(button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    public void Set()
    {
        icon.sprite = item.d_Icon;
        countText.text = count >= 1 ? count.ToString() : string.Empty;
        priceText.text = item.d_Price.ToString();
    }

    public void Clear()
    {
        item = null;
        count = 0;
        icon.sprite = null;
        countText.text = string.Empty;
        priceText.text = string.Empty;
    }

    public void OnButtonClicked()
    {
        inventory.SelectItem(idx);
    }
}