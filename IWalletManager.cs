using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// Interface IwalletManage is to manage the Wallet Balance and balance of the User
    /// </summary>
    public interface IWalletManager
    {
        /// <summary>
        /// Property Wallet Balance is used to get and set the wallet balance of the user
        /// </summary>
        /// <value></value>
        public double WalletBalance { get; set; }

        /// <summary>
        /// Method WalletRecharge is used to Recharge the USer Wallet
        /// </summary>
        /// <param name="amount">ammount is type of double which is going to add in balance</param>
        public void WalletRecharge(double amount);
        /// <summary>
        /// Method DeductBalance is used to Recharge the USer Wallet
        /// </summary>
        /// <param name="amount">ammount is type of double which is going to deduct in balance</param>
        public bool DeductBalance(double amount);

    }
}