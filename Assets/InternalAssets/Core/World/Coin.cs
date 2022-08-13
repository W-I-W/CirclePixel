using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int Count = 0;

    [SerializeField] private int m_Coin = 1;

    private void OnEnable()
    {
        Count++;
    }

    private void OnDisable()
    {
        UIManager ui = UIManager.Instance;
        Count--;
        if (Count == 0)
            ui.UIEnable(ui.UIWin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCharacter = collision.gameObject.TryGetComponent(out Wallet wallet);

        if (isCharacter)
        {
            wallet.Coins += m_Coin;
            gameObject.SetActive(false);
        }
    }
}
