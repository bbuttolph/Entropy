// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.Extensions.Localization;

namespace Mvc.LocalizationSample.Web
{
    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            var defaultProvider = new ValidationAttributeAdapterProvider();

            var adapter = defaultProvider.GetAttributeAdapter(attribute, stringLocalizer);

            if (adapter == null)
            {
                var type = attribute.GetType();

                if (type == typeof(NotEqualToAttribute))
                {
                    adapter = new NotEqualToAttributeAdapter((NotEqualToAttribute)attribute, stringLocalizer);
                }
            }

            return adapter;
        }
    }
}