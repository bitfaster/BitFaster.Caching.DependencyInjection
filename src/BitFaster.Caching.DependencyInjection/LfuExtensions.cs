using System;
using BitFaster.Caching.Lfu;
using BitFaster.Caching.Lfu.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BitFaster.Caching.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up <see cref="ConcurrentLfu{K,V}" /> caches in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class LfuExtensions
    {
        /// <summary>
        /// Adds an <see cref="ICache{K,V}" /> backed by <see cref="ConcurrentLfu{K,V}" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The builder delegate used to configure the cache.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddLfu<K, V>(this IServiceCollection services, Func<ConcurrentLfuBuilder<K, V>, ICache<K, V>> configure)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(configure);

            var builder = new ConcurrentLfuBuilder<K, V>();
            services.TryAddSingleton<ICache<K, V>>(configure(builder));
            return services;
        }

        /// <summary>
        /// Adds an <see cref="IAsyncCache{K,V}" /> backed by <see cref="ConcurrentLfu{K,V}" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The builder delegate used to configure the cache.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAsyncLfu<K, V>(this IServiceCollection services, Func<AsyncConcurrentLfuBuilder<K, V>, IAsyncCache<K, V>> configure)
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(configure);

            var builder = new ConcurrentLfuBuilder<K, V>().AsAsyncCache();
            services.TryAddSingleton<IAsyncCache<K, V>>(configure(builder));
            return services;
        }

        /// <summary>
        /// Adds an <see cref="IScopedCache{K,V}" /> backed by <see cref="ConcurrentLfu{K,V}" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The builder delegate used to configure the cache.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddScopedLfu<K, V>(this IServiceCollection services, Func<ScopedConcurrentLfuBuilder<K, V, Scoped<V>>, IScopedCache<K, V>> configure) where V : IDisposable
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(configure);

            var builder = new ConcurrentLfuBuilder<K, V>().AsScopedCache();
            services.TryAddSingleton<IScopedCache<K, V>>(configure(builder));
            return services;
        }

        /// <summary>
        /// Adds an <see cref="IScopedAsyncCache{K,V}" /> backed by <see cref="ConcurrentLfu{K,V}" /> to the <see cref="IServiceCollection" />.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="configure">The builder delegate used to configure the cache.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddScopedAsyncLfu<K, V>(this IServiceCollection services, Func<ScopedAsyncConcurrentLfuBuilder<K, V>, IScopedAsyncCache<K, V>> configure) where V : IDisposable
        {
            ThrowHelper.ThrowIfNull(services);
            ThrowHelper.ThrowIfNull(configure);

            var builder = new ConcurrentLfuBuilder<K, V>().AsAsyncCache().AsScopedCache();
            services.TryAddSingleton<IScopedAsyncCache<K, V>>(configure(builder));
            return services;
        }
    }
}
