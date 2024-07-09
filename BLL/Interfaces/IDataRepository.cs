using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IDataRepository
	{
		Task<IEnumerable<MainData>> GetAllAsync();
		Task<MainData> GetByIdAsync(int id);
		Task AddAsync(MainData record);
		void Delete(MainData record);

	}
}
