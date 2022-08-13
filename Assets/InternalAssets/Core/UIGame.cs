using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class UIGame : MonoBehaviour
{
    private Label m_LableMoney;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        m_LableMoney = root.Q<Label>("Money");
    }

    public void MoneyChange(int money)
    {
        m_LableMoney.text = $"{money}$";
    }
}
