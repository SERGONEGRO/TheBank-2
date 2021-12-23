using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheBank2.Model
{
    //interface ICheckable<T>
    //{
    //    bool CheckDepositForMoneyAmount(T MoneyOnSourceDeposit, T RequiredMoney);
    //}

    static class DepositTransfer//<T> : ICheckable<T>
    {
        public static  bool CheckDepositForMoneyAmount(Double MoneyOnSourceDeposit, Double RequiredMoney)
        {
            if (RequiredMoney <= MoneyOnSourceDeposit) { return true; }
            else return false;
        }
    }
}
