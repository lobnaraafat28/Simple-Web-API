using BLL.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class DataRepository : IDataRepository
	{
		private readonly DBContext _context;

		public DataRepository(DBContext context)
		{
			_context = context;
		}
		public async Task AddAsync(MainData record)
		{
			await _context.MainData.AddAsync(record);
			_context.SaveChanges();
		}

		public void Delete(MainData record)
		{
			_context.MainData.Remove(record);
			_context.SaveChanges();
		}

		public async Task<IEnumerable<MainData>> GetAllAsync()
		=> await _context.MainData.ToListAsync();
		

		public async Task<MainData> GetByIdAsync(int id)
			=> await _context.MainData.FindAsync(id);
			
		
	}
}
