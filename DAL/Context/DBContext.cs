
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
	public class DBContext : DbContext
	{
		public DBContext(DbContextOptions<DBContext> options):base(options) { }
		
		public DbSet<MainData> MainData { get; set; }

	}
}
