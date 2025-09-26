// See https://aka.ms/new-console-template for more information

using Observability.ConsoleApp;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

Console.WriteLine("Hello, World!");

var traceProvider = Sdk.CreateMeterProviderBuilder()
    .ConfigureResource(configure =>
    {
        configure.AddService(OpenTelemetryConstant.ServiceName, OpenTelemetryConstant.ServiceVersion)
        .AddAttributes(new List<KeyValuePair<string, object>>()
        {
            new KeyValuePair<string ,object>("host.machineName",
            Environment.MachineName),
            new KeyValuePair<string, object>("host.environment",
            "dev")
        });
    }).Build();




