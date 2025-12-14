using Observability.ConsoleApp;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;



var traceProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(OpenTelemetryConstant.ActivitySourgeName)
    .ConfigureResource(configure =>
    {
        configure
        .AddService(OpenTelemetryConstant.ServiceName, OpenTelemetryConstant.ServiceVersion)
        .AddAttributes(new List<KeyValuePair<string, object>>()
        {
            new KeyValuePair<string ,object>("host.machineName",
            Environment.MachineName),
            new KeyValuePair<string, object>("host.environment",
            "dev")
        });
    }).AddConsoleExporter().Build();

var serviceHelper = new ServiceHelper();
await serviceHelper.Work1();

