# BitFaster.Caching.DependencyInjection
Extension methods for setting up [caches](https://github.com/bitfaster/BitFaster.Caching/wiki/Caches) using [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/).

# ConcurrentLru

To use with an `IServiceCollection` instance at startup:

```cs
services.AddLru<int, string>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```

This adds a `ConcurrentLru` where the key is an integer and the cached value is a string. The builder delegate is used to configure the registered cache with a capacity of 666, see the [wiki](https://github.com/bitfaster/BitFaster.Caching/wiki/ConcurrentLru-Quickstart#builder-api) for more details about the builder API and configurable cache features.

There is an extension method for each [cache interface](https://github.com/bitfaster/BitFaster.Caching/wiki/Caches):

| Extension | Result | 
|-----------|--------|
| `AddLru<TKey, TValue>` | Registers `ConcurrentLru<TKey, TValue>` as a singleton `ICache<TKey, TValue>` |
| `AddAsyncLru<TKey, TValue>` | Registers `ConcurrentLru<TKey, TValue>` as a singleton `IAsyncCache<TKey, TValue>` |
| `AddScopedLru<TKey, TValue>` | Registers `ConcurrentLru<TKey, TValue>` as a singleton `IScopedCache<TKey, TValue>` |
| `AddScopedAsyncLru<TKey, TValue>` | Registers `ConcurrentLru<TKey, TValue>` as a singleton `IScopedAsyncCache<TKey, TValue>` |


# ConcurrentLfu

To use with an `IServiceCollection` instance at startup:

```cs
services.AddLfu<int, string>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```

This adds a `ConcurrentLfu` where the key is an integer and the cached value is a string. The builder delegate is used to configure the registered cache with a capacity of 666, see the [wiki](https://github.com/bitfaster/BitFaster.Caching/wiki/ConcurrentLfu-Quickstart#builder-api) for more details about the builder API and configurable cache features.

There is an extension method for each [cache interface](https://github.com/bitfaster/BitFaster.Caching/wiki/Caches):

| Extension | Result | 
|-----------|--------|
| `AddLfu<TKey, TValue>` | Registers `ConcurrentLfu<TKey, TValue>` as a singleton `ICache<TKey, TValue>` |
| `AddAsyncLfu<TKey, TValue>` | Registers `ConcurrentLfu<TKey, TValue>` as a singleton `IAsyncCache<TKey, TValue>` |
| `AddScopedLfu<TKey, TValue>` | Registers `ConcurrentLfu<TKey, TValue>` as a singleton `IScopedCache<TKey, TValue>` |
| `AddScopedAsyncLfu<TKey, TValue>` | Registers `ConcurrentLfu<TKey, TValue>` as a singleton `IScopedAsyncCache<TKey, TValue>` |