using System;
using System.Collections.Generic;
using System.Linq;
using MiniCrm.Models;


namespace MiniCrm.Services
{
    public class CustomerService
    {
        private List<Customer> _customers = new();
        private int _nextId = 1;

        // create

        public bool Add(string fullName, string email, string phone, string notes)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            if (!email.Contains("@"))
            {
                return false;
            }

            var customer = new Customer
            {
                Id = _nextId++,
                FullName = fullName,
                Email = email,
                Phone = phone,
                Notes = notes
            };
            _customers.Add(customer);
            return true;
        }


        // read

        public List<Customer> GetAll()
        {
            return _customers;
        }


        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }


        // update

        public bool Update(int id, string fullName, string email, string phone, string notes)
        {
            var customer = GetById(id);

            if (customer == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            customer.FullName = fullName;
            customer.Email = email;
            customer.Phone = phone;
            customer.Notes = notes;

            return true;
        }


        // delete

        public bool delete(int id)
        {
            var customer = GetById(id);

            if(customer == null)
            {
                return false;
            }
            else
            {
                _customers.Remove(customer);
                return true;
            }
        }

        //! bool dönüşler başarılı olup olmadığını belirtmek için kullanılır.
        //! UI katmanında bu dönüşlere göre kullanıcıya mesaj gösterilebilir.
    }
}