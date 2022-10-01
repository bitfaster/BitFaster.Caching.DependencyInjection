using BitFaster.Caching.Lru;

namespace BitFaster.Caching.DependencyInjection.UnitTests
{
    public class LruExtensionsTests
    {
        private IServiceCollection services = new TestServiceCollection();

        [Fact]
        public void AddLru()
        {
            services.AddLru<int, int>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<FastConcurrentLru<int, int>, ICache<int, int>>();

            throw new Exception("failed");
        }

        [Fact]
        public void AddAsyncLru()
        {
            services.AddAsyncLru<int, int>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<FastConcurrentLru<int, int>, IAsyncCache<int, int>>();
        }

        [Fact]
        public void AddScopedLru()
        {
            services.AddScopedLru<int, Disposable>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ScopedCache<int, Disposable>, IScopedCache<int, Disposable>>();
        }

        [Fact]
        public void AddScopedAsyncLru()
        {
            services.AddScopedAsyncLru<int, Disposable>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ScopedAsyncCache<int, Disposable>, IScopedAsyncCache<int, Disposable>>();
        }
    }
}