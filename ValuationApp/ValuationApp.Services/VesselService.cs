﻿using AutoMapper;
using ValuationApp.DataAccess.Repository.Contracts;
using ValuationApp.Entities;
using ValuationApp.Services.Contract;
using ValuationApp.ValuationDto;

namespace ValuationApp.Services
{
    public class VesselService : IVesselService
    {
        public readonly IVesselRepository _vesselRepository;
        public readonly IMapper _mapper;

        public VesselService(IVesselRepository vesselRepository, IMapper mapper)
        {
            _vesselRepository = vesselRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(VesselDto vessel)
        {
            var existedVessel = await _vesselRepository.GetByImo(vessel.Imo);

            if(existedVessel != null) {
                throw new Exception("Vessel exist");
            }

            var vesselToAdd = _mapper.Map<Vessel>(vessel);
            return await _vesselRepository.Create(vesselToAdd);
        }

        public async Task<VesselDto> GetById(int id)
        {
            var vessel = await _vesselRepository.GetById(id);

            return _mapper.Map<VesselDto>(vessel);
        }
    }
}