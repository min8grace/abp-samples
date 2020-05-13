﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TextTemplateDemo.Demos.Hello;
using TextTemplateDemo.Demos.PasswordReset;
using Volo.Abp;

namespace TextTemplateDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<TextTemplateDemoModule>(options =>
            {
                options.UseAutofac();
            }))
            {
                application.Initialize();

                var helloDemo = application.ServiceProvider.GetRequiredService<HelloDemo>();
                var passwordResetDemo = application.ServiceProvider.GetRequiredService<PasswordResetDemo>();

                await helloDemo.RunAsync();
                await helloDemo.RunWithAnonymousModelAsync();

                await passwordResetDemo.RunAsync();

                Console.WriteLine();
                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();

                application.Shutdown();
            }
        }
    }
}
