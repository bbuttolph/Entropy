// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Mvc.LocalizationSample.Web
{
    public class NotEqualToAttribute : ValidationAttribute
    {
        public object Value { get; }

        public NotEqualToAttribute(object value)
        {
            Value = value;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Value.ToString());
        }

        public override bool IsValid(object value)
        {
            return !Value.Equals(value);
        }
    }
}
