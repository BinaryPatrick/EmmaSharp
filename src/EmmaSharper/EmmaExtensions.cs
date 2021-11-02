using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EmmaSharper.Adapters;
using EmmaSharper.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("EmmaSharper.Unit")]
namespace EmmaSharper
{
    /// <summary>Extension methods for <see cref="EmmaSharper"/></summary>
    public static class EmmaSharperExtensions
    {
        /// <summary>Add Emma API Providers</summary>
        public static IServiceCollection AddEmmaApiProviders(this IServiceCollection services, Action<EmmaOptions> optionConfiguration)
        {
            services.AddTransient(sp =>
            {
                EmmaOptions options = new EmmaOptions();
                optionConfiguration(options);
                return options;
            });

            services.AddEmmaProviders();

            return services;
        }

        /// <summary>Add base Emma services and providers</summary>
        internal static void AddEmmaProviders(this IServiceCollection services)
        {
            services.AddTransient<IRestClientFactory, RestClientFactory>();
            services.AddTransient<IEmmaApiAdapter, EmmaApiAdapter>();

            services.AddTransient<IAutomationProvider, AutomationProvider>();
            services.AddTransient<IFieldsProvider, FieldsProvider>();
            services.AddTransient<IGroupProvider, GroupProvider>();
            services.AddTransient<IMailingProvider, MailingProvider>();
            services.AddTransient<IMemberProvider, MemberProvider>();
            services.AddTransient<IResponseProvider, ResponseProvider>();
            services.AddTransient<ISearchProvider, SearchProvider>();
            services.AddTransient<ISignupFormProvider, SignupFormProvider>();
            services.AddTransient<ISubscriptionProvider, SubscriptionProvider>();
            services.AddTransient<IWebhookProvider, WebhookProvider>();
        }

        /// <summary>Convert enum to string</summary>
        internal static string ToEnumString<T>(this T @enum) where T : Enum
        {
            string value = @enum.ToString();
            EnumMemberAttribute attribute = typeof(T).GetField(value)?
                .GetCustomAttributes<EnumMemberAttribute>(false)
                .SingleOrDefault();

            if (attribute is null)
            {
                return value;
            }

            return attribute.Value;
        }

        /// <summary>Converts a <see cref="Enum"/> into its direct string value, or attribute value when attributed.</summary>
        internal static IEnumerable<string> AsEnumStrings<T>(this IEnumerable<T> enums) where T : Enum
            => enums.Select(x => x.ToEnumString());

        /// <summary>Syntactic sugar for <see cref="string.Join(char, string[])"/></summary>
        internal static string JoinWith(this IEnumerable<string> items, char seperator)
            => string.Join(seperator, items);
    }
}
