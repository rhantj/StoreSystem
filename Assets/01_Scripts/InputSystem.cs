using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    DefaultInput inputActions;

    private void Awake()
    {
        inputActions = new DefaultInput();
        inputActions.UI.I.started += OnlyInventoryToggle;
        inputActions.UI.Tab.started += FullViewToggle;
        inputActions.UI.E.started += FullViewToggle;
        inputActions.UI.ESC.started += FullViewToggle;
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    private void OnlyInventoryToggle(InputAction.CallbackContext obj)
    {
        IUIToggleable.TriggerInventoryToggled();
    }

    private void FullViewToggle(InputAction.CallbackContext obj)
    {
        IUIToggleable.TriggerFullViewToggled();
    }
}
