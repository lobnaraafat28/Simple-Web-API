using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practical.APIs.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecordController : ControllerBase
	{
		private readonly IDataRepository _dataRepo;

		public RecordController(IDataRepository repo)
		{
			_dataRepo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllRecords()
		{
			if(_dataRepo != null)
			{
				var data = await _dataRepo.GetAllAsync();
				return Ok(data);
			}
			return null;

		}
		
		[HttpPost]
		public async Task<IActionResult> AddRecord(MainData newRecord)
		{
			var record = new MainData() { Name = newRecord.Name, Activated = newRecord.Activated };
			if (record == null) return BadRequest();
			else
			{
				await _dataRepo.AddAsync(record);
				return Ok(record);
			}
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteRecord(int id)
		{
			if (id == 0) return BadRequest();
			else
			{
				var recordDeleted = await _dataRepo.GetByIdAsync(id);
				if (recordDeleted != null)
				   _dataRepo.Delete(recordDeleted);
				else
					return NotFound();
				
				return Ok();
			}
		}

	}
}
