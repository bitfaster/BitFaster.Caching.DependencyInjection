# BitFaster.Caching.DependencyInjection
Extension methods for setting up caches using Microsoft.Extensions.DependencyInjection.

# ConcurrentLru

```cs
services.AddLru<int, int>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```


# ConcurrentLfu

```cs
services.AddLfu<int, int>(builder =>
    builder
        .WithCapacity(666)
        .Build());
```
