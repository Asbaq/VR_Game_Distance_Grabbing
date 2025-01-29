# VR Game Distance Grabbing 🚀

![VR](https://user-images.githubusercontent.com/62818241/210204601-6ccb90cb-0f9e-428e-8a75-01b9e1e810ef.PNG)

## 📌 Introduction
The **VR Game Distance Grabbing** feature enhances the interaction in VR games by enabling users to grab and manipulate objects from a distance using VR controllers. It leverages Unity's XR Toolkit and Input System to offer intuitive and immersive gameplay, where players can interact with distant objects, adding a layer of complexity and fun to the VR experience.

## 🔥 Features
- 🖐️ **Distance Grabbing**: Grab and interact with objects from a distance using controller inputs.
- 🎮 **Hand Animation**: Smooth hand animations triggered by pinch and grip gestures.
- 🎧 **XR Headset Info**: Provides real-time information on connected VR headsets for debugging purposes.

---

## 🏗️ How It Works
This feature includes multiple scripts that handle different actions, such as hand animations and VR headset status checks.

### 📌 **AnimateHandOnInput Script**
This script controls hand animations based on the pinch and grip inputs. It smoothly animates the hand based on the values of the controller actions.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);
        
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
```

### 📌 **HMD_Info_Manager Script**
This script checks if a VR headset is connected, and logs its status. It helps verify if the VR device is properly recognized by Unity, ensuring proper VR setup.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMD_Info_Manager : MonoBehaviour
{
    void Start()
    {
        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset Plugged");
        }
        else if(XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockMDDisplay"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("We Have a headset " + XRSettings.loadedDeviceName);
        }
    }

    void Update() { }
}
```

---

## 🎯 Conclusion
This **VR Game Distance Grabbing** feature brings interactive gameplay to a whole new level by enabling users to grab objects from a distance. With smooth hand animations and real-time VR headset information, the feature enhances immersion and adds a layer of depth to the player’s experience. By utilizing Unity’s XR Toolkit and Input System, it provides responsive and intuitive controls for an engaging VR experience. 🚀🌟
