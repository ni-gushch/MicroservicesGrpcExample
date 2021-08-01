using System;
using System.IO;
using MicroservicesGrpcExample.Platform.Books.Contracts.Configurations;

namespace MicroservicesGrpcExample.Platform.Books.DataAccess.Configurations
{
    public class SqLiteDbConfiguration : DbConfiguration
    {
        public new string ConnectionString { get; set; } =
            $"Data Source={Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}" +
            $"{Path.DirectorySeparatorChar}booklibrary.db";
    }
}