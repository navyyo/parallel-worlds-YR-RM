using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
{
    private Camera cam;
    private void Awake() => cam = Camera.main;
    private void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                {
                    keypadButton.PressButton();
                }
            }
        }
    }
}
}
/*using UnityEngine;

namespace NavKeypad
{
    public class KeypadInteractionFPV : MonoBehaviour
    {
        private Camera cam;

        private void Awake() => cam = Camera.main;

        private void Update()
        {
            
            // Check if the cursor is locked before processing mouse input
            if (Cursor.lockState == CursorLockMode.None)
            {
                var ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.Log("Keypad Interaction Update1");

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Keypad Interaction Update2");
                    if (Physics.Raycast(ray, out var hit))
                    {
                        Debug.Log("Hit collider: " + hit.collider.name);
                        if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                        {
                            Debug.Log("Keypad Interaction Update44");
                            keypadButton.PressButton();
                        }
                    }

                }
            }
        }
    }
}*/
