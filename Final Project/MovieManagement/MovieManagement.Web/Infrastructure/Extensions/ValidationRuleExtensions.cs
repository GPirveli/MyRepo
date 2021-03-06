using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieManagement.Web.Infrastructure.Extensions
{
    public static class ValidationRuleExtensions
    {
        public static IRuleBuilderOptions<T, string> Passport<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^[0-9a-zA-Z]+$"));
        }

        public static IRuleBuilderOptions<T, string> Phone<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(x => Regex.IsMatch(x, @"^5\d{8}$"));
        }
    }
}
