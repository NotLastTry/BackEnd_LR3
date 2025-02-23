using Microsoft.Extensions.DependencyInjection;

namespace BackEnd_Нагорнов_А.В._ЛР3
{
    interface ILogService //Создаём интерфейс.
    {
        void Log(string message);
    }
    class SimpleLogService : ILogService //Реализуем интерфейс.
    {
        public void Log(string message) => Console.Write(message);
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection(); //Создание коллекции для хранения сервисов.
            services.AddTransient<ILogService,SimpleLogService>(); //Добавление сервиса в коллекцию.
            using var serviceProvider = services.BuildServiceProvider(); //Создаёт ServiceProvider, в котором будут храниться вызываемые сервисы.
            ILogService? logService= serviceProvider.GetService<ILogService>(); //Создаём переменную и присваиваем ей значение сервиса.
            logService.Log("Логирование."); //Вызываем метод Log сервиса.
        } 
    }
}
