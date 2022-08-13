using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int m_Coins = 0;
    [SerializeField] private UnityEvent<int> m_MoneyChange;

    private void Start()
    {
        Coins = Coins;
    }

    public int Coins
    {
        get => m_Coins;
        set
        {
            m_Coins = value;
            m_MoneyChange?.Invoke(m_Coins);
        }
    }
}
