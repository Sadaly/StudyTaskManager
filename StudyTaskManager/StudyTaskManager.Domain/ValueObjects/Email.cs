﻿using StudyTaskManager.Domain.Common;
using StudyTaskManager.Domain.Errors;
using StudyTaskManager.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyTaskManager.Domain.ValueObjects
{
    [ComplexType]
    public sealed class Email : ValueObject
    {
        //private Email() { Value = ""; }
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        /// <summary>
        /// Создание экземпляра <see cref="Email"/>  с проверкой входящих значений
        /// </summary>
        /// <param name="email">Строка с почтой</param>
        /// <returns>Новый экземпляр <see cref="Email"/></returns>
        public static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return Result.Failure<Email>(DomainErrors.Email.Empty);
            }

            if (email.Split('@').Length != 2)
            {
                return Result.Failure<Email>(DomainErrors.Email.InvalidFormat);
            }

            return new Email(email);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
