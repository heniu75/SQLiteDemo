﻿using SharedLib.Model;

namespace SharedLib.Data
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(long id);
        void SaveCustomer(Customer customer);
    }
}