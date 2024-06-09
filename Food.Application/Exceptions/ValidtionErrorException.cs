using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Exceptions
{
	public class ValidtionErrorException : Exception
	{
		public ValidtionErrorException() : base("one or more validation occured")
		{
			Errors = new List<string>();
		}
		public List<string> Errors { get; set; }

		public ValidtionErrorException(List<ValidationFailure> failures) : this()
		{
			foreach (var failure in failures)
			{
				Errors.Add(failure.ErrorMessage);
			}
		}
	}
}