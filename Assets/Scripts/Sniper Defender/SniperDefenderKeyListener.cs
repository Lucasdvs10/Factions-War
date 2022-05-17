using System;
using UnityEngine;

public class SniperDefenderKeyListener : MonoBehaviour
{
    public string keyboardKey = "space";

    public event Action<Vector3> OnPressKeyEvent;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyboardKey))
            WorldMousePosition();
    }

    private void WorldMousePosition()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = Camera.main.nearClipPlane; // Brings mouse z position near to camera z position
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        OnPressKeyEvent?.Invoke(worldMousePosition);
        
    }
}
