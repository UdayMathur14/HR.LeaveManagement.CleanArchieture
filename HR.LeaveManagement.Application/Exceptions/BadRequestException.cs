﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class BadRequestException :Exception
    {
        public BadRequestException(string message) : base(message)
        {

        }


        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
            
        }

        public IDictionary<string , string[]> ValidationErrors { get; set; }
    }
}
