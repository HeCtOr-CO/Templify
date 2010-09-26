#region License

//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

#endregion

namespace Endjin.Templify.Specifications
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;

    using Endjin.Templify.Domain.Domain.Packager.Specifications;
    using Endjin.Templify.Domain.Contracts.Infrastructure;
    using Endjin.Templify.Domain.Infrastructure;

    using Machine.Specifications;
    using Machine.Specifications.AutoMocking.Rhino;

    #endregion

    public abstract class specification_for_command_line_processor
    {
        protected static string[] create_command_line_args;
        protected static string[] deploy_command_line_args;

        protected static ICommandLineProcessor subject;

        Establish context = () =>
            {
                
                create_command_line_args = new [] 
                { 
                    "-m",
                    "c",
                    "-p",
                    @"C:\Temp\Package-Samples",
                    "-n", 
                    "Sharp Architecture",
                    "-a", 
                    "Howard van Rooijen" ,
                    "-v",
                    "1.6.0.0",
                    "-t", 
                    "SA169=__NAME__", 
                    "ServerName01=__SERVERNAME__"
                };

                deploy_command_line_args = new[] 
                { 
                    "-m",
                    "d",
                    "-p",
                    @"C:\Temp\Package-Samples",
                    "-i",
                    "sharp-architecture-v1.6.0.0",
                    "-t", 
                    "__NAME__=SA169", 
                    "__SERVERNAME__=ServerName01"
                };
            };
    } ;

    [Subject(typeof(CommandLineProcessor))]
    public class when_the_command_line_processor_is_given_a_valid_list_of_create_package_args_to_process : specification_for_command_line_processor
    {
        static CommandOptions result;

        Establish context = () =>
            {
                subject = new CommandLineProcessor();
            };

        Because of = () => result = subject.Process(create_command_line_args); 

        It should_return_create_mode = () => result.Mode.ShouldEqual(Mode.Create);
        It should_return_the_correct_package_path = () => result.Path.ShouldEqual(@"C:\Temp\Package-Samples");
        It should_return_the_correct_name = () => result.Name.ShouldEqual(@"Sharp Architecture");
        It should_return_the_correct_author = () => result.Author.ShouldEqual(@"Howard van Rooijen");
        It should_return_the_correct_version_number = () => result.Version.ShouldEqual("1.6.0.0");
        It should_return_the_correct_number_of_tokens = () => result.Tokens.Count.ShouldEqual(2);
        It should_return_the_correct_first_token = () => result.Tokens["SA169"].ShouldEqual("__NAME__");
        It should_return_the_correct_second_token = () => result.Tokens["ServerName01"].ShouldEqual("__SERVERNAME__");
    }

    [Subject(typeof(CommandLineProcessor))]
    public class when_the_command_line_processor_is_given_a_valid_list_of_deploy_package_args_to_process : specification_for_command_line_processor
    {
        static CommandOptions result;

        Establish context = () =>
        {
            subject = new CommandLineProcessor();
        };

        Because of = () => result = subject.Process(deploy_command_line_args);

        It should_return_deploy_mode = () => result.Mode.ShouldEqual(Mode.Deploy);
        It should_return_the_correct_package_path = () => result.Path.ShouldEqual(@"C:\Temp\Package-Samples");
        It should_return_the_correct_number_of_tokens = () => result.Tokens.Count.ShouldEqual(2);
        It should_return_the_correct_first_token = () => result.Tokens["__NAME__"].ShouldEqual("SA169");
        It should_return_the_correct_second_token = () => result.Tokens["__SERVERNAME__"].ShouldEqual("ServerName01");
    }
}