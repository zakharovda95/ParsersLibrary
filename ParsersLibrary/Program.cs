using Microsoft.Extensions.Configuration;

var configFilePath = AppDomain.CurrentDomain.BaseDirectory;
var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(configFilePath).AddJsonFile("appsettings.Development.json");
var configuration = configurationBuilder.Build();

Console.ReadLine();

