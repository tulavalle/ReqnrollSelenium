﻿using Microsoft.Extensions.Configuration;

namespace ReqnrollSelenium.Support
{
    public class GetAppSettingsConfig
    {
        protected GetAppSettingsConfig() { }

        private static string _testProjectDirectory = string.Empty;
        public static string TestProjectDirectory { get => _testProjectDirectory; }

        private static IConfigurationRoot _configuration;

        /// <summary>
        /// Verifica de já possui as configurações, se não, as procura no appsettings.json.
        /// </summary>
        public static IConfigurationRoot Configuration
        {
            get
            {
                if (_configuration == null)
                    Setup();

                return _configuration ?? throw new Exception("Não foi possível ler o arquivo de configuração. Verifique.");
            }
        }

        /// <summary>
        /// Inicializa o diretório padrão, onde o arquivo de configuração appsettings.json está localizado.
        /// </summary>
        /// <param name="testProjectDirectory">Diretório padrão do projeto</param>
        public static void Initialize(string testProjectDirectory)
        {
            _testProjectDirectory = testProjectDirectory;
        }

        /// <summary>
        /// Busca as configurações do appsettings.json.
        /// </summary>
        private static void Setup(string configFile = "appsettings.json")
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                            .AddJsonFile(configFile);

            _configuration = builder.Build();
        }
    }
}
