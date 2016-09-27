// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Mvc.LocalizationSample.Web
{
    public class NotEqualToAttribute : ValidationAttribute
    {
        public NotEqualToAttribute(object value)
        {
            Value = value;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Convert.ToString(Value));
        }

        public override bool IsValid(object value)
        {
            return !string.Equals(Convert.ToString(Value), Convert.ToString(value), StringComparison.CurrentCultureIgnoreCase);
        }

        public object Value { get; set; }
    }
}
