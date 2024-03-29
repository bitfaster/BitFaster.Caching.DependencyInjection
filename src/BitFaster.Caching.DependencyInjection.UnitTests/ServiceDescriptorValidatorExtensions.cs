﻿
namespace BitFaster.Caching.DependencyInjection.UnitTests
{
    public static class ServiceDescriptorValidatorExtensions
    {
        public static void IsSingleton<TImpl, TSvc>(this ServiceDescriptor sd)
        {
            sd.ImplementationFactory.Should().BeNull();
            sd.ImplementationInstance.Should().BeOfType<TImpl>();
            sd.Lifetime.Should().Be(ServiceLifetime.Singleton);
            sd.ServiceType.Should().Be(typeof(TSvc));
        }
    }
}
