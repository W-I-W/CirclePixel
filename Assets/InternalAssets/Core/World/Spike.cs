using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isCharacter = collision.gameObject.TryGetComponent(out Character wallet);

        if (isCharacter)
        {
            UIManager ui = UIManager.Instance;
            ui.UIEnable(ui.UIGameOver);
        }
    }
}
