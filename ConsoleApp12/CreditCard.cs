using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public delegate void AccountStateHandlere(string messege);
    class CreditCard
    {
        string number_card { get; set; }    
        string fuul_name { get; set; }
        DateTime validity_period {  get; set; }
        int pin { get; set; }
        decimal credit_limit { get; set; }
        decimal balance {  get; set; }

        public CreditCard(string _number_card, string _fuul_name, DateTime _validity_period, int _pin, decimal _credit_limit, decimal _balance) 
        {
            number_card = _number_card;
            fuul_name = _fuul_name;
            validity_period = _validity_period;
            pin = _pin;
            credit_limit = _credit_limit;
            balance = _balance;
        }

        public void ShowCard() 
        {
            OnShow?.Invoke("\nТекущий баланс: " + balance.ToString() +
                           "\nВаше Фио: " + fuul_name +
                           "\nСрок действия карты: " + validity_period +
                           "\nPIN: " + pin +
                           "\nСумма денег: " + credit_limit); 

        }   

        // Метод для пополнения баланса
        public void Replenishment(decimal _balance) 
        {
            if (_balance > 0)
            {
                balance = _balance;

                OnReplenishment?.Invoke("Вы пополнили счёт на " + _balance.ToString() + ".Текущий баланс: " + balance.ToString());        
            }
            else
            {
                OnReplenishment?.Invoke("Укажите сумму для пополнения");
            }
        }

        // Метод для расхода денег для счёта
        public void Consumption(decimal _balance) 
        {
            if (_balance > 0 && _balance <= balance)   
            {
                balance -= _balance;

                if (balance > 0)
                {
                    OnSpending?.Invoke("С вашего счёта снято " + _balance.ToString() + ". Текущий баланс: " + balance.ToString());
                }
                else
                {
                    OnStartCredit?.Invoke("С вашего счёта снято " + _balance.ToString() + ". Теперь вы используете крдитные деньги, так как на счету не осталось средств");
                }

            }
            else
            {   
                OnSpending?.Invoke("На вашем счету недостаточно средств. Текущий баланс: " + balance.ToString());    
            }
        }

        // Метод достижение заданной суммы денег;
        public void Accumulator(decimal money) 
        {
            if (balance >= money) 
            {
                OnAccumulator?.Invoke("Ваш баланс соответсвует заданной суме денег");
            } 
            else
            {
                decimal remainder = money - balance;    
                OnAccumulator?.Invoke("Вам осталось накопить: " + remainder);   
            }
        }

        // Метод для смены PIN
        public void ChangePin(int newPin)
        {
            if (newPin != pin)
            {
                pin = newPin;
                OnPinChange?.Invoke("PIN-код успешно изменен на " + newPin);
            }
            else
            {
                OnPinChange?.Invoke("новый PIN-код должен отличаться от текущего.");
            }
        }

        public event AccountStateHandlere OnShow;
        public event AccountStateHandlere OnReplenishment; 
        public event AccountStateHandlere OnSpending; 
        public event AccountStateHandlere OnStartCredit;
        public event AccountStateHandlere OnAccumulator;
        public event AccountStateHandlere OnPinChange;

    }
}
