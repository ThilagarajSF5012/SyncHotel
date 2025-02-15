using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncHotel
{
    /// <summary>
    /// class UserRegistration is used to Create the objcet for the UserREgistration and it inherits the personal Details class and IwalletManager Interface
    /// </summary>
    public class UserRegistration : PersonalDetails, IWalletManager
    {

        private static int s_userID = 1000;
        private string _userID;
        public string UserID { get { return _userID; } set { _userID = value; s_userID = int.Parse(value.Remove(0, 2)); } }
        private double _balance;
        /// <summary>
        /// Property Wallet Balance is used to get and set the wallet balance of the user
        /// </summary>
        /// <value></value>
        public double WalletBalance { get { return _balance; } set { _balance = value; } }

        /// <summary>
        /// Constructor to initialize the object without the parameter
        /// </summary>
        public UserRegistration()
        {

        }

        public UserRegistration(string name, string mobile, string aadhar, string email, string address, FoodType food, GenderType gender, double balance) : base(name, mobile, aadhar, email, address, food, gender)
        {
            UserID = $"SF{++s_userID}";
            _balance = balance;
        }

        ///     /// <summary>
        /// Method DeductBalance is used to Recharge the USer Wallet
        /// </summary>
        /// <param name="amount">ammount is type of double which is going to deduct in balance</param>

        public bool DeductBalance(double amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method WalletRecharge is used to Recharge the USer Wallet
        /// </summary>
        /// <param name="amount">ammount is type of double which is going to add in balance</param>
        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }
    }
}