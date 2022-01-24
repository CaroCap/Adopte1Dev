using Adopte1Dev.BLL.Entities;
using Adopte1Dev.Common;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDeveloperRepository<DeveloperBLL> service = new Adopte1Dev.BLL.Repositories.DeveloperService(new Adopte1Dev.DAL.Repositories.DeveloperService());
            IEnumerable<DeveloperBLL> developers = service.Get();
            foreach (DeveloperBLL developer in developers)
            {
                Console.WriteLine(JsonSerializer.Serialize(developer));
            }
        }
    }
}
