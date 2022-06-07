﻿using AutoMapper;
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

        public async Task<DispositionDTO> Create(DispositionDTO disp)
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
                var save = await _repo.Create(mapped);

                var map = _mapper.Map<DispositionDTO>(save);

                return map;
            }
            catch
            {
                throw new Exception("Failed to create disposition");
            }
        }

        public async Task<bool> Delete(DispositionDTO dispositionDTO)
        {
            try
            {
                var mapped = _mapper.Map<DispositionDTO, Disposition>(dispositionDTO);
                await _repo.Delete(mapped);

                return true;
            }
            catch
            {
                throw new Exception("Failed to delete disposition");
            }
        }

        public async Task<DispositionDTO> Get(int id)
        {
            try
            {
                var acc = await _repo.Get(id);

                return _mapper.Map<DispositionDTO>(acc);
            }
            catch
            {
                throw new Exception("Failed to get account");
            }
        }

        public async Task<DispositionDTO> Update(DispositionDTO dispositionDTO)
        {
            try
            {
                var acc = _mapper.Map<DispositionDTO, Disposition>(dispositionDTO);

                var res = await _repo.Update(acc);

                return _mapper.Map<DispositionDTO>(res);
            }
            catch
            {
                throw new Exception("Failed to update account");
            }
        }
    }
}
