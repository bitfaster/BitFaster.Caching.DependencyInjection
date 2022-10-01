Extension methods for setting up caches using Microsoft.Extensions.DependencyInjection.

# ConcurrentLru

To use with an `IServiceCollection` instance at startup:

```cs
services.AddLru<int, int>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```

The builder delegate can be used to configure the cache, see the [wiki](https://github.com/bitfaster/BitFaster.Caching/wiki/ConcurrentLru-Quickstart#builder-api) for details.

There is an extension method for each [cache interface](https://github.com/bitfaster/BitFaster.Caching/wiki/Caches):

| Extension | Result | 
|-----------|--------|
| AddLru | Registers `ConcurrentLru<int, int>` as a singleton `ICache<int, int>` |
| AddAsyncLru | Registers `ConcurrentLru<int, int>` as a singleton `IAsyncCache<int, int>` |
| AddScopedLru | Registers `ConcurrentLru<int, Disposable>` as a singleton `IScopedCache<int, Disposable>` |
| AddScopedAsyncLru | Registers `ConcurrentLru<int, Disposable>` as a singleton `IScopedAsyncCache<int, Disposable>` |


# ConcurrentLfu

To use with an `IServiceCollection` instance at startup:

```cs
services.AddLfu<int, int>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```

The builder delegate can be used to configure the cache, see the [wiki](https://github.com/bitfaster/BitFaster.Caching/wiki/ConcurrentLfu-Quickstart#builder-api) for details.

There is an extension method for each [cache interface](https://github.com/bitfaster/BitFaster.Caching/wiki/Caches):

| Extension | Result | 
|-----------|--------|
| AddLfu | Registers `ConcurrentLfu<int, int>` as a singleton `ICache<int, int>` |
| AddAsyncLfu | Registers `ConcurrentLfu<int, int>` as a singleton `IAsyncCache<int, int>` |
| AddScopedLfu | Registers `ConcurrentLfu<int, Disposable>` as a singleton `IScopedCache<int, Disposable>` |
| AddScopedAsyncLfu | Registers `ConcurrentLfu<int, Disposable>` as a singleton `IScopedAsyncCache<int, Disposable>` |
