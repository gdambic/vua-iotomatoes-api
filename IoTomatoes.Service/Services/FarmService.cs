﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IoTomatoes.Application.Interfaces;
using IoTomatoes.Application.Models;
using IoTomatoes.Domain.Interfaces;
using IoTomatoes.Domain.Models;

namespace IoTomatoes.Application.Services
{
    public class FarmService : IFarmService
    {
        private readonly IFarmRepository _farmRepository;
        private readonly IRuleSetRepository _ruleSetRepository;
        private readonly IMapper _mapper;

        public FarmService(IFarmRepository farmRepository, IRuleSetRepository ruleSetRepository, IMapper mapper)
        {
            _farmRepository = farmRepository;
            _ruleSetRepository = ruleSetRepository;
            _mapper = mapper;
        }

        public FarmDTO Get(int farmId)
        {
            var farm = _farmRepository.Get(farmId);

            if(farm != null)
            {
                return MapFarm(farm);
            }

            return null;
        }
    
        public List<FarmDTO> GetAll()
        {
            var farms = _farmRepository.GetAll();
            return farms.Select(MapFarm).ToList();
        }

        public RuleSetDTO GetRuleSet(int farmId)
        {
            var farm = _farmRepository.Get(farmId);
            var ruleSet = _ruleSetRepository.Get(farm.RuleSetId.Value);
            var rules = _ruleSetRepository.GetRules(farm.RuleSetId.Value);
            ruleSet.Rules = rules;
            return MapRuleSet(ruleSet);
        }

        private RuleSetDTO MapRuleSet(RuleSet ruleSet)
        {
            return new RuleSetDTO
            {
                Id = ruleSet.Id,
                Code = ruleSet.Code,
                Name = ruleSet.Name,
                Rules = ruleSet.Rules.Select(MapRule).ToList()
            };
        }

        private RuleDTO MapRule(Rule rule)
        {
            return new RuleDTO
            {
                Code = rule.Code.TrimEnd(),
                Conditions = rule.Conditions,
                Active = rule.Active.Value != 0,
                RuleSetId = rule.RuleSetId.Value
            };
        }

        private FarmDTO MapFarm(Farm farm)
        {
            return new FarmDTO
            {
                Id = farm.Id,
                Name = farm.Name,
                Address = farm.Address,
                Description = farm.Description,
                Latitude = farm.Latitude.Value,
                Longitude = farm.Longitude.Value,
                DateCreated = farm.DateCreated.Value
            };
        }
    }
}
