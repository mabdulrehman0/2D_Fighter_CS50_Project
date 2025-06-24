using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Keybind : MonoBehaviour
{
    public static Keybind instance;

    public string current_action_to_rebind = "";
    private bool isRebinding = false;

    // Define the mapping of key actions to their display labels
    [System.Serializable]
    public class KeybindDisplay
    {
        public string actionName;
        public TextMeshProUGUI displayText;
    }

    // Fill this list from the Unity Inspector
    public List<KeybindDisplay> keybindUIList = new List<KeybindDisplay>();

    // Dictionary to access display text by action name
    private Dictionary<string, TextMeshProUGUI> keybindUIDict = new Dictionary<string, TextMeshProUGUI>();

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Build the dictionary from the list
        foreach (var item in keybindUIList)
        {
            keybindUIDict[item.actionName] = item.displayText;

            // Load saved key (or show default if not found)
            if (PlayerPrefs.HasKey(item.actionName))
            {
                item.displayText.text = PlayerPrefs.GetString(item.actionName);
            }
            else
            {
                item.displayText.text = "Unassigned";
            }
        }
    }
    // the rebind function which start the process of rebinding.
    public void Rebind(string actionName)
    {
        isRebinding = true;
        current_action_to_rebind = actionName;

        if (keybindUIDict.ContainsKey(actionName))
        {
            keybindUIDict[actionName].text = "Press a key...";
        }
    }

    void Update()
    {
        if (isRebinding && current_action_to_rebind != "")
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    PlayerPrefs.SetString(current_action_to_rebind, key.ToString());
                    keybindUIDict[current_action_to_rebind].text = key.ToString();
                    current_action_to_rebind = "";
                    isRebinding = false;
                    break;
                }
            }
        }
        PlayerPrefs.Save();
    }
}