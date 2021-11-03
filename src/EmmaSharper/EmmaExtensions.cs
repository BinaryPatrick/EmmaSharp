using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using EmmaSharper.Adapters;
using EmmaSharper.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("EmmaSharper.Unit")]
namespace EmmaSharper
{
    /// <summary>Extension methods for <see cref="EmmaSharper"/></summary>
    public static class EmmaSharperExtensions
    {
        /// <summary>Add Emma API Providers</summary>
        public static IServiceCollection AddEmmaApiProviders(this IServiceCollection services, IConfiguration configuration)
            => services.AddEmmaApiProviders(configuration.Bind);

        /// <summary>Add Emma API Providers</summary>
        public static IServiceCollection AddEmmaApiProviders(this IServiceCollection services, Action<EmmaOptions> action)
        {
            services.AddTransient(sp =>
            {
                EmmaOptions options = new EmmaOptions();
                action(options);
                return options;
            });

            services.AddEmmaProviders();

            return services;
        }

        /// <summary>Add base Emma services and providers</summary>
        internal static void AddEmmaProviders(this IServiceCollection services)
        {
            services.AddTransient<IEmmaRestClientFactory, EmmaRestClientFactory>();
            services.AddTransient<IEmmaApiAdapter, EmmaApiAdapter>();

            services.AddTransient<IEmmaAutomationProvider, AutomationProvider>();
            services.AddTransient<IEmmaFieldsProvider, FieldsProvider>();
            services.AddTransient<IEmmaGroupProvider, GroupProvider>();
            services.AddTransient<IEmmaMailingProvider, MailingProvider>();
            services.AddTransient<IEmmaMemberProvider, MemberProvider>();
            services.AddTransient<IEmmaResponseProvider, ResponseProvider>();
            services.AddTransient<IEmmaSearchProvider, SearchProvider>();
            services.AddTransient<IEmmaSignupFormProvider, SignupFormProvider>();
            services.AddTransient<IEmmaSubscriptionProvider, SubscriptionProvider>();
            services.AddTransient<IEmmaWebhookProvider, WebhookProvider>();
        }

        /// <summary>Convert <see cref="Enum"/> to <see cref="string"/></summary>
        internal static string ToEnumString<T>(this T @enum) where T : Enum
        {
            string value = @enum.ToString();
            EnumMemberAttribute attribute = typeof(T).GetField(value)?
                .GetCustomAttributes<EnumMemberAttribute>(false)
                .SingleOrDefault();

            return attribute is null ? value : attribute.Value;
        }

        /// <summary>Converts a <see cref="Enum"/> into its direct string value, or attribute value when attributed.</summary>
        internal static IEnumerable<string> AsEnumStrings<T>(this IEnumerable<T> enums) where T : Enum
            => enums.Select(x => x.ToEnumString());

        /// <summary>Syntactic sugar for <see cref="string.Join(char, string[])"/></summary>
        internal static string JoinWith(this IEnumerable<string> items, char seperator)
            => string.Join(seperator, items);
    }
}
