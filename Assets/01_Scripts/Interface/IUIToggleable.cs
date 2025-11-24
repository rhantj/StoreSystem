using System;

public interface IUIToggleable
{
    public static event Action OnInventoryToggled;
    public static event Action OnFullViewToggled;

    public static void TriggerInventoryToggled()
    {
        OnInventoryToggled?.Invoke();
    }

    public static void TriggerFullViewToggled()
    {
        OnFullViewToggled?.Invoke();
    }
}