﻿using System;
using System.Collections.Generic;

namespace IoTomatoes.Persistence.Models
{
    public partial class Rules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Conditions { get; set; }
        public int? Active { get; set; }
        public int? RuleSetId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual RuleSets RuleSet { get; set; }
    }
}
