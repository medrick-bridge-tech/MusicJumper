using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    private int collectedCoin = 0;

    [SerializeField] Text coinCountText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    void CollectCoin(GameObject coin)
    {
        collectedCoin++;
        Destroy(coin);
        UpdateCoinCountUI();
    }

    void UpdateCoinCountUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = ": " + collectedCoin.ToString();
        }
    }
}
