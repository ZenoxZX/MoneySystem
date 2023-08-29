using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZenoxZX.Money
{
    [Serializable]
    public class MoneySystem
    {
        /// <summary>
        /// Total Money Amount
        /// </summary>
        public event Action<int> OnMoneyChange;

        /// <summary>
        /// Increased Money Amount
        /// </summary>
        public event Action<int> OnMoneyIncrease;

        /// <summary>
        /// Decreased Money Amount
        /// </summary>
        public event Action<int> OnMoneyDecrease;

        private const string PREF_MONEY = "PREF_MONEY";
        private const string PREF_EARNED_MONEY = "PREF_EARNED_MONEY";
        private const int STARTING_MONEY = 0;

        public int Money { get; private set; }
        public int EarnedMoney { get; private set; }

        public void Initialize()
        {
            SetMoney(LoadMoney());
            EarnedMoney = LoadEarnedMoney();
        }

        public void IncreaseMoney(int value)
        {
            SetMoney(Money + value);
            EarnedMoney += value;
            SaveEarnedMoney(EarnedMoney);
        }

        public bool DecreaseMoney(int value)
        {
            bool canDecrease = Money >= value;

            if (canDecrease)
                SetMoney(Money - value);

            return canDecrease;
        }

        private void SetMoney(int value)
        {
            Money = value;
            OnMoneyChange?.Invoke(value);
            SaveMoney(value);
        }

        private void SaveMoney(int value) => PlayerPrefs.SetInt(PREF_MONEY, value);
        public int LoadMoney() => PlayerPrefs.GetInt(PREF_MONEY, STARTING_MONEY);
        private void SaveEarnedMoney(int value) => PlayerPrefs.SetInt(PREF_EARNED_MONEY, value);
        private int LoadEarnedMoney() => PlayerPrefs.GetInt(PREF_EARNED_MONEY, 0);

    }
}