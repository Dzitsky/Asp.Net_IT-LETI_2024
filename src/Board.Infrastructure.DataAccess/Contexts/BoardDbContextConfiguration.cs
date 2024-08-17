using Board.Infrastructure.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastructure.DataAccess.Contexts
{
    public class BoardDbContextConfiguration : IDbContextOptionsConfigurator<BoardDbContext>
    {

        private const string PostgesConnectionStringName = "PostgresBoardDb";

        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;

        public BoardDbContextConfiguration(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public void Configure(DbContextOptionsBuilder<BoardDbContext> options)
        {
            var connectionString = _configuration.GetConnectionString(PostgesConnectionStringName);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    message:$"Не найдена строка подключения с именем бд '{PostgesConnectionStringName}'");
            }
            options.UseNpgsql(connectionString);
            options.UseLoggerFactory(_loggerFactory);
        }
    }
}
