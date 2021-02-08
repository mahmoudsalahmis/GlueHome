using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlueHome.Application.Exceptions
{
    public class ValidationException : Exception
    {
        private const string Msg = "One or more validation failures have occurred.";

        public ValidationException()
            : base(Msg)
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Failures = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(ArgumentException ex) : base(Msg, ex)
        {
            Failures = new Dictionary<string, string[]>();

            Failures.Add(ex.ParamName ?? string.Empty, new[] {
                ex.Message
            });
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
