using AutoMapper;
using Bank.Core.Interfaces;
using Bank.Data.Repos;
using Bank.Domain.DTOs;
using Bank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Services
{
    public class DispositionService : IDispositionService
    {
        private readonly DispositionRepo _repo;
        private readonly IMapper _mapper;

        public DispositionService(DispositionRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public DispositionDTO Create(DispositionDTO disp)
        {
            try
            {
                DispositionDTO dto = new()
                {
                    AccountId = disp.AccountId,
                    CustomerId = disp.CustomerId,
                    Type = disp.Type,
                };

                var mapped = _mapper.Map<DispositionDTO, Disposition>(dto);
                var save = _repo.Create(mapped);

                var map = _mapper.Map<DispositionDTO>(save);

                return map;
            }
            catch
            {
                throw new Exception("Failed to create disposition");
            }
        }

        public bool Delete(DispositionDTO customer)
        {
            throw new NotImplementedException();
        }

        public DispositionDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public DispositionDTO Update(DispositionDTO customer)
        {
            throw new NotImplementedException();
        }
    }
}
