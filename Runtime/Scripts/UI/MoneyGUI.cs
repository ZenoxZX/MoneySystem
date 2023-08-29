using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZenoxZX.UI;
using TMPro;
using System;

namespace ZenoxZX.Money.UI
{
    [Serializable]
    public class MoneyGUI : GUIBase
    {
        [SerializeField] TextMeshProUGUI moneyTMP;
        private MoneySystem moneySystem;

        public void Initialize(MoneySystem moneySystem)
        {
            base.Initialize();
            OnMoneyChange(moneySystem.Money);
            moneySystem.OnMoneyChange += OnMoneyChange;
            this.moneySystem = moneySystem;
        }

        private void OnMoneyChange(int money) => moneyTMP.SetText(money.ToString());
        public void OnDestroy() => moneySystem.OnMoneyChange -= OnMoneyChange;
    }
}
