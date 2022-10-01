using BitFaster.Caching.Lfu;

namespace BitFaster.Caching.DependencyInjection.UnitTests
{
    public class LfuExtensionsTests
    {
        private IServiceCollection services = new TestServiceCollection();

        [Fact]
        public void AddLfu()
        {
            services.AddLfu<int, int>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ConcurrentLfu<int, int>, ICache<int, int>>();
        }

        [Fact]
        public void AddAsyncLfu()
        {
            services.AddAsyncLfu<int, int>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ConcurrentLfu<int, int>, IAsyncCache<int, int>>();
        }

        [Fact]
        public void AddScopedLfu()
        {
            services.AddScopedLfu<int, Disposable>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ScopedCache<int, Disposable>, IScopedCache<int, Disposable>>();
        }

        [Fact]
        public void AddScopedAsyncLfu()
        {
            services.AddScopedAsyncLfu<int, Disposable>(builder =>
                builder
                    .WithCapacity(666)
                    .Build());

            services.Count.Should().Be(1);
            services[0].IsSingleton<ScopedAsyncCache<int, Disposable>, IScopedAsyncCache<int, Disposable>>();
        }
    }
}
