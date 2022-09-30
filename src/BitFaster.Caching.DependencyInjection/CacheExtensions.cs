using BitFaster.Caching.Lfu;
using BitFaster.Caching.Lru;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace BitFaster.Caching.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up caches in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Adds a <see cref="ConcurrentLru{K,V}" />to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">A delegate which can use a cache builder to build a cache.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddConcurrentLru<K, V>(this IServiceCollection services, Action<ConcurrentLruBuilder<K, V>> configure)
        {
            // this is not so simple because the builder can change the return type.

            var builder = new ConcurrentLruBuilder<K, V>();
            configure(builder);
            services.TryAddSingleton<ICache<K, V>>(builder.Build());
            return services;
        }

        public static IServiceCollection AddConcurrentLfu<K, V>(this IServiceCollection services, Action<ConcurrentLfuBuilder<K, V>> configure)
        {
            var builder = new ConcurrentLfuBuilder<K, V>();
            configure(builder);
            services.TryAddSingleton<ICache<K, V>>(builder.Build());
            return services;
        }
    }
}
