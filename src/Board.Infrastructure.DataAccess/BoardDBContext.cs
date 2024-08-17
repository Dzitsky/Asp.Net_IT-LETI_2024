using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infrastructure.DataAccess
{

    /// <summary>
    /// Контекст БД
    /// </summary>
    public class BoardDbContext : DbContext
    {

        /// <summary>
        /// Инициализирует экземпляр <see cref="BoardDbContext"/>
        /// </summary>
        public BoardDbContext(DbContextOptions options)
            : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), t => t.GetInterfaces().Any(i =>
            i.IsGenericType &&
            i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
        }

    }
}
