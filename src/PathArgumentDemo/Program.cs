using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace PathArgumentDemo
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandApp();
            app.SetDefaultCommand<SampleCommand>();
            return app.Run(args);
        }
    }

    public class SampleCommand : Command<SampleCommand.Settings> {
        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            return 0;
        }

        public class Settings : CommandSettings {

            public override ValidationResult Validate()
            {
                AnsiConsole.MarkupLine($"[grey]inputPath:[/] {InputPath}");
                AnsiConsole.MarkupLine($"[grey]outputName:[/] {(OutputName ?? "null")}");
                return base.Validate();
            }

            [CommandArgument(0, "<inputPath>")]
            [Description("A path to use as an input for a generic operation.")]
            public string InputPath {get;set;}

            [CommandArgument(1, "[outputName]")]
            [Description("An arbitrary argument to come after the input path argument.")]
            public string OutputName {get;set;}
        }
    }
}
