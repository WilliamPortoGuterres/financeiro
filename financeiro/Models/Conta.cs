using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace financeiro.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; private set; }
        public string AccountNumber { get; set; }
        public DateTime CreatedAt { get; private set; }

        public Conta()
        {
            CreatedAt = DateTime.Now;
        }

        public void Deposito(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("O valor do depósito deve ser positivo.");
            }

            Balance += amount;
        }

        public void Saque(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException("O valor do saque deve ser positivo.");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Saldo insuficiente para o saque.");
            }

            Balance -= amount;
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidOperationException("O nome da conta é obrigatório.");
            }

            
        }
    }
}
