using System;

namespace BankAccountNS
{
    /// <summary>
    /// Класс банковского счёта для демонстрации модульного тестирования.
    /// Предоставляет методы для управления балансом: пополнение и списание средств.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        /// <summary>
        /// Константа сообщения об ошибке: сумма списания превышает баланс.
        /// </summary>
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        /// <summary>
        /// Константа сообщения об ошибке: сумма списания меньше нуля.
        /// </summary>
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";

        private BankAccount() { }

        /// <summary>
        /// Конструктор создания банковского счёта.
        /// </summary>
        /// <param name="customerName">Имя владельца счёта.</param>
        /// <param name="balance">Начальный баланс счёта.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        /// <summary>
        /// Имя владельца счёта.
        /// </summary>
        /// <value>Строка с именем клиента.</value>
        public string CustomerName
        {
            get { return m_customerName; }
        }

        /// <summary>
        /// Текущий баланс счёта.
        /// </summary>
        /// <value>Числовое значение текущего баланса.</value>
        public double Balance
        {
            get { return m_balance; }
        }

        /// <summary>
        /// Метод списания денежных средств со счёта.
        /// </summary>
        /// <param name="amount">Сумма к списанию (должна быть больше 0 и не превышать баланс).</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если amount превышает баланс или меньше нуля.
        /// </exception>
        /// <remarks>
        /// При корректном значении amount баланс уменьшается на указанную сумму.
        /// </remarks>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);

            if (amount < 0)
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);

            m_balance -= amount;
        }

        /// <summary>
        /// Метод пополнения счёта (зачисление денежных средств).
        /// </summary>
        /// <param name="amount">Сумма к зачислению (должна быть больше 0).</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Генерируется, если amount меньше нуля.
        /// </exception>
        /// <remarks>
        /// При корректном значении amount баланс увеличивается на указанную сумму.
        /// </remarks>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new System.ArgumentOutOfRangeException("amount", amount, "Credit amount is less than zero");

            m_balance += amount;
        }

        /// <summary>
        /// Точка входа в программу. Демонстрирует работу класса BankAccount.
        /// </summary>
        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Roman Abramovich", 11.99);

            try { ba.Debit(100.00); }
            catch (ArgumentOutOfRangeException e)
            { Console.WriteLine("[Тест 1] " + e.Message); }

            try { ba.Debit(-50.00); }
            catch (ArgumentOutOfRangeException e)
            { Console.WriteLine("[Тест 2] " + e.Message); }

            try { ba.Credit(-20.00); }
            catch (ArgumentOutOfRangeException e)
            { Console.WriteLine("[Тест 3] " + e.Message); }

            Console.ReadLine();
        }
    }
}
