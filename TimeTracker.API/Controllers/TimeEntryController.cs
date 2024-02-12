using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        public static List<TimeEntry> _timeEntries = new List<TimeEntry>
        {
            new TimeEntry { 
                Id = 1, 
                Project = "Project 1", 
                End = DateTime.Now.AddHours(1) 
            },
        };

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAllTimeEntries()
        {
            return Ok(_timeEntries);
        }

        [HttpGet("{id}")]
        public ActionResult<TimeEntry> GetTimeEntryById(int id)
        {
            var timeEntry = _timeEntries.FirstOrDefault(x => x.Id == id);
            if (timeEntry == null)
            {
                return NotFound();
            }
            return Ok(timeEntry);
        }

        [HttpPost]
        public ActionResult<TimeEntry> AddTimeEntry(TimeEntry timeEntry)
        {
            timeEntry.Id = _timeEntries.Count + 1;
            _timeEntries.Add(timeEntry);
            return CreatedAtAction(nameof(GetTimeEntryById), new { id = timeEntry.Id }, timeEntry);
        }

    }
}
