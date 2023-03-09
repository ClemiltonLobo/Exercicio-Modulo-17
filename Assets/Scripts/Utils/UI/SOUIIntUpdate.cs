using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI uiTextValue;

    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
        soInt.onValueChanged += OnValueChanged;
    }

    private void OnValueChanged(int newValue)
    {
        uiTextValue.text = newValue.ToString();
    }

    private void OnDestroy()
    {
        soInt.onValueChanged -= OnValueChanged;
    }
}
