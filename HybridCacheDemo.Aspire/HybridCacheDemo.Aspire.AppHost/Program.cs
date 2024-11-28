var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache-redis",4040).WithRedisInsight();

var apiService = builder.AddProject<Projects.HybridCacheDemo_Aspire_ApiService>("apiservice")
    .WithExternalHttpEndpoints()
    .WaitFor(cache)
    .WithReference(cache);

builder.Build().Run();
