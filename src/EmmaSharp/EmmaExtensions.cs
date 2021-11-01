using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EmmaSharp.Adapters;
using EmmaSharp.Services;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("EmmaSharp.Unit")]
namespace EmmaSharp
{
    public static class EmmaExtensions
    {
        public static IServiceCollection AddEmmaProviders(this IServiceCollection services, Action<EmmaOptions> optionConfiguration)
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

        /// <summary>Syntactic sugar for <see cref="string.Join(char, string?[]"/></summary>
        internal static string JoinWith(this IEnumerable<string> items, char seperator)
            => string.Join(seperator, items);

        /// <summary>Syntactic sugar for <see cref="string.Join(string, string?[]"/></summary>
        internal static string JoinWith(this IEnumerable<string> items, string seperator)
            => string.Join(seperator, items);
    }
}
