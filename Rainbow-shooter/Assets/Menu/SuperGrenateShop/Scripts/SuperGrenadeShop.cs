using System;
using UnityEngine;
using TMPro;

public class SuperGrenadeShop : MonoBehaviour
{
    public Action OnBought;
    [SerializeField] private TMP_Text currentCountText;
    [SerializeField] private GameObject addSuperGrenadeImage;

    private int _currentCount;
    public int CurrentCount
    {
        get
        {
            return _currentCount;
        }

        set
        {
            _currentCount = value;
            if (currentCountText != null)
                currentCountText.text = _currentCount.ToString();
            Progress.SaveSuperGrenades(_currentCount);
            OnBought?.Invoke();
        }
    }

    private void OnEnable()
    {
        CurrentCount = Progress.LoadSuperGrenades();
    }

    public void TryRewardOne()
    {
        GSConnect.Purchase(GSConnect.SuperGrenade);
    }

    public void RewardOne()
    {
        CurrentCount++;

        addSuperGrenadeImage.SetActive(true);
    }
}
