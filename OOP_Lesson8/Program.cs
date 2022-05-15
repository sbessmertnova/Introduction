using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static OOP_Lesson8.Const;

namespace OOP_Lesson8
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).Build();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            var pageSize = config.GetValue<int>("PageSize");
            var methods = new Helpers(pageSize);

            var showInfoCommand = CommandParser.GetShowInfoCommand();
            CommandExecutor.Execute(showInfoCommand);

            var exit = false;
            var keys = Const.GetAllCommandInfos().Select(command=> command.inputKey);
            while (!exit)
            {
                var userLine = Console.ReadLine();

                var command = CommandParser.ParseToCommand(userLine);

                try
                {
                    CommandExecutor.Execute(command);
                }
                catch(Exception x)
                {
                    Console.WriteLine(x);
                }

            }
        }
    }
}
