using System;
using ConsoleEFCore.Models;
using ConsoleEFCore.Presentation;
using ConsoleEFCore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
  
namespace ConsoleEFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      using IHost host = GetInstaciaHostBuilder(args).Build();
      Start(host.Services);
    }

    
    private static IHostBuilder GetInstaciaHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostBuilderContext, services) => ConfigureServices(services));

    private static void ConfigureServices(IServiceCollection services) => services
      .AddDbContext<HospitalContext>()
      .AddTransient<CrudPacienteView>()
      .AddTransient<CrudMedicoView>()
      .AddTransient<CrudConsultaView>()
      .AddTransient<CrudEnfermariaView>()
      .AddTransient<CrudUsuarioView>()
      .AddTransient<IRepository<Paciente>, PacienteRepository>()
      .AddTransient<IRepository<Medico>, MedicoRepository>()
      .AddTransient<IRepository<Consulta>, ConsultaRepository>()
      .AddTransient<IRepository<Enfermaria>, EnfermariaRepository>()
      .AddTransient<IRepository<Usuario>, UsuarioRepository>()
      .AddIdentity<Usuario, IdentityRole>()
      .AddEntityFrameworkStores<HospitalContext>();

    private static void Start(IServiceProvider provider)
    {
      while (true)
      {
        Console.Clear();

        Console.WriteLine("Bem vindo ao Hospital Lambda!!");
        Console.WriteLine("Fique a vontade para navegar no nosso menu");

        Console.WriteLine("1- Paciente");
        Console.WriteLine("2- Médico");
        Console.WriteLine("3- Consulta");
        Console.WriteLine("4- Enfermaria");
        Console.WriteLine("5- Usuário");

        Console.WriteLine("\nEscolha uma opção");
        int opcao;
        Int32.TryParse(Console.ReadLine(), out opcao);

        CrudBaseView crud;
        switch (opcao)
        {
          case 1:
            crud = provider.GetService<CrudPacienteView>();
            break;
          case 2:
            crud = provider.GetService<CrudMedicoView>();
            break;
          case 3:
            crud = provider.GetService<CrudConsultaView>();
            break;
          case 4:
            crud = provider.GetService<CrudEnfermariaView>();
            break;
          case 5:
            crud = provider.GetService<CrudUsuarioView>();
            break;
          default:
            return;
        }
        crud.Executar();
      }
    }
  }
}
