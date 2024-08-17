using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastructure.DataAccess.Interfaces
{
    /// <summary>
    /// Конфигурация контекста
    /// </summary>
    public interface IDbContextConfiguration<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Выполняет конфигурацию контекста
        /// </summary>
        /// <param name="options">настройки</param>
        void Configure(DbContextOptionsBuilder<TContext> options);
    }
}
