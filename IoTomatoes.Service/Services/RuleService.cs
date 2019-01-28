﻿using System;
using System.Collections.Generic;
using AutoMapper;
using IoTomatoes.Application.Interfaces;
using IoTomatoes.Application.Models;
using IoTomatoes.Domain.Interfaces;

namespace IoTomatoes.Application.Services
{
    public class RuleService : IRuleService
    {
        private readonly IRuleRepository _ruleRepository;
        private readonly IMapper _mapper;

        public RuleService(IRuleRepository ruleRepository, IMapper mapper)
        {
            _ruleRepository = ruleRepository;
            _mapper = mapper;
        }

        public Dictionary<string, string> GetDictionary(List<RuleDTO> rules)
        {
            var _rules = new Dictionary<string, string>();

            foreach(var rule in rules)
            {
                _rules.Add(rule.Code.Trim(), rule.Conditions);
            }

            return _rules;
        }
    }
}
