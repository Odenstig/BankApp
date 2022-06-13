using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Interfaces;
using Bank.Domain.DTOs;
using Bank.Domain.Models;

namespace Bank.Core.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IAccountTypeRepo _repo;
        private readonly IMapper _mapper;

        public AccountTypeService(IAccountTypeRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AccountTypeDTO> Create(AccountTypeDTO accountTypeDTO)
        {
            try
            {
                var list = await _repo.GetAll();

                foreach (var item in list)
                {
                    if (accountTypeDTO.TypeName == item.TypeName)
                    {
                        throw new Exception("Failed to create accounttype");
                    }
                }

                AccountTypeDTO acc = new()
                {
                    Description = accountTypeDTO.Description,
                    Interest = accountTypeDTO.Interest,
                    TypeName = accountTypeDTO.TypeName,
                };

                var mapped = _mapper.Map<AccountTypeDTO, AccountType>(acc);
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<AccountTypeDTO>(save);

                return map;

            }
            catch
            {
                throw new Exception("Failed to create accounttype");
            }
        }

        public async Task<AccountTypeDTO> Get(int id)
        {
            try
            {
                var acc = await _repo.Get(id);

                return _mapper.Map<AccountTypeDTO>(acc);
            }
            catch
            {
                throw new Exception("Failed to get account");
            }
        }

        public async Task<List<AccountTypeDTO>> GetAll()
        {
            var acc = await _repo.GetAll();

            return _mapper.Map<List<AccountTypeDTO>>(acc);
        }
    }
}
