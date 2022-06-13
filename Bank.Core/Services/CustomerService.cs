using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Interfaces;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> Create(CustomerDTO customerDTO)
        {
            try
            {
                CustomerDTO acc = new()
                {
                    Gender = customerDTO.Gender,
                    Givenname = customerDTO.Givenname,
                    Surname = customerDTO.Surname,
                    Streetaddress = customerDTO.Streetaddress,
                    City = customerDTO.City,
                    Zipcode = customerDTO.Zipcode,
                    Country = customerDTO.Country,
                    CountryCode = customerDTO.CountryCode,
                    Birthday = customerDTO.Birthday,
                    Telephonecountrycode = customerDTO.Telephonecountrycode,
                    Telephonenumber = customerDTO.Telephonenumber,
                    Emailaddress = customerDTO.Emailaddress,
                };

                var mapped = _mapper.Map<CustomerDTO, Customer>(acc);
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<CustomerDTO>(save);

                return map;
            }
            catch
            {
                throw new Exception("Failed to create account");
            }
        }

        public async Task<bool> Delete(CustomerDTO customerDTO)
        {
            try
            {
                var mapped = _mapper.Map<CustomerDTO, Customer>(customerDTO);
                await _repo.Delete(mapped);

                return true;
            }
            catch
            {
                throw new Exception("Failed to delete account");
            }
        }

        public async Task<CustomerDTO> Get(int id)
        {
            try
            {
                var acc = await _repo.Get(id);

                return _mapper.Map<CustomerDTO>(acc);
            }
            catch
            {
                throw new Exception("Failed to get account");
            }
        }

        public async Task<CustomerDTO> Update(CustomerDTO customerDTO)
        {
            try
            {
                var acc = _mapper.Map<CustomerDTO, Customer>(customerDTO);

                var res = await _repo.Update(acc);

                return _mapper.Map<CustomerDTO>(res);
            }
            catch
            {
                throw new Exception("Failed to update account");
            }
        }
    }
}
