using UnityEngine;

public class SniperDefender : MonoBehaviour
{
    public string keyboardKey;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(keyboardKey))
            Debug.Log(WorldMousePosition());
    }

    private Vector3 WorldMousePosition()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        screenMousePosition.z = Camera.main.nearClipPlane; // Brings mouse z position near to camera z position
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        return worldMousePosition;
    }
}
