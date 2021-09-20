using System.Collections.Generic;

using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Templates;
using Serilog.Templates.Themes;

using Araumi.Server.Extensions;

namespace Araumi.Server.Services {
  // public class SerilogLogger : Swan.Logging.ILogger {
  // 	public LogLevel LogLevel { get; }
  //
  // 	public void Log(LogMessageReceivedEventArgs args) {
  // 		throw new NotImplementedException();
  // 	}
  //
  // 	public void Dispose() {
  // 		throw new NotImplementedException();
  // 	}
  // }

  public interface ILoggerService {
    public void Init();
  }

  [Service]
  public class LoggerService : ILoggerService {
    private static readonly ILogger Logger = Log.Logger.ForType<LoggerService>();

    private static readonly TemplateTheme Theme = new TemplateTheme(new Dictionary<TemplateThemeStyle, string>() {
      [TemplateThemeStyle.Text] = "\u001B[38;5;0253m",
      [TemplateThemeStyle.SecondaryText] = "\u001B[38;5;0246m",
      [TemplateThemeStyle.TertiaryText] = "\u001B[38;5;0242m",
      [TemplateThemeStyle.Invalid] = "\u001B[33;1m",
      [TemplateThemeStyle.Null] = "\u001B[38;5;0038m",
      [TemplateThemeStyle.Name] = "\u001B[38;5;0081m",
      [TemplateThemeStyle.String] = "\u001B[38;5;0216m",
      [TemplateThemeStyle.Number] = "\u001B[38;5;151m",
      [TemplateThemeStyle.Boolean] = "\u001B[38;5;0038m",
      [TemplateThemeStyle.Scalar] = "\u001B[38;5;0079m",
      [TemplateThemeStyle.LevelVerbose] = "\u001B[34m",
      [TemplateThemeStyle.LevelDebug] = "\u001b[36m",
      [TemplateThemeStyle.LevelInformation] = "\u001B[32m",
      [TemplateThemeStyle.LevelWarning] = "\u001B[33;1m",
      [TemplateThemeStyle.LevelError] = "\u001B[31;1m",
      [TemplateThemeStyle.LevelFatal] = "\u001B[31;1m"
    });

    public LogEventLevel MinimumLevel {
      get => _level.MinimumLevel;
      set => _level.MinimumLevel = value;
    }

    private readonly LoggingLevelSwitch _level;

    public LoggerService() {
      _level = new LoggingLevelSwitch() {
        MinimumLevel = LogEventLevel.Verbose
      };
    }

    public void Init() {
      LoggerConfiguration config = new LoggerConfiguration()
          .MinimumLevel.ControlledBy(_level)
          .Enrich.WithThreadId()
          .Enrich.WithThreadName()
          .Enrich.FromLogContext()
          .WriteTo.Console(new ExpressionTemplate(
            "[{@t:HH:mm:ss.fff}] ({ThreadId}{#if ThreadName is not null}/{ThreadName}{#end}) [{@l}] {#if SourceContext is not null}[{SourceContext}] {#end}{#if @p['PlayerLogDisplay'] is not null}[{@p['PlayerLogDisplay']}] {#end}{@m:lj}\n{@x}",
            theme: Theme
          ))
        /* .WriteTo.File(
          "Araumi.Server.log",
          rollingInterval: RollingInterval.Day,
          rollOnFileSizeLimit: true
        ) */;

      Log.Logger = config.CreateLogger();

      // Disable other loggers
      Swan.Logging.Logger.NoLogging();
      // Swan.Logging.Logger.RegisterLogger<SerilogLogger>();

      Logger.Information("Initialized");
    }
  }
}
