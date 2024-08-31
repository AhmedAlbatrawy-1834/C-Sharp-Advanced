namespace CAReflectionAndMetadata
{
    /*#################### Reflecting Members Class####################*/
    //                              And
    /*#################### Invoking Members Class ####################*/
    public class BankAccount
    {
        private string _accountNo;
        private string _holderName;
        private decimal _amount;

        public string AccountNo => _accountNo;
        public string HolderName => _holderName;
        public decimal Amount => _amount;
        public event EventHandler OnNegativeBalance;
        public BankAccount()
        {
            
        }
        public BankAccount(string accountNo, string holderName, decimal amount)
        {
            _accountNo = accountNo;
            _holderName = holderName;
            _amount = amount;
        }


        public void Deposit(decimal amount)
        {
            this._amount += amount;
        }
        public void Withdraw(decimal amount)
        {
            this._amount-= amount;
            if(_amount < 0)
            {
                OnNegativeBalance.Invoke(this, null);
            }
        }
        public override string ToString()
        {
            return $"{{AccountNo:{AccountNo},   Holder:{_holderName},   Balance:${_amount}}}";
        }
    }




}
