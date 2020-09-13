using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Data.Models.Models.ReturnedModels;
using QuotesApi.Data.Repositories.Abstract;

namespace QuotesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SubjectController : Controller
    {
        private ISubjectRepository subjectRepository;
        
        public SubjectController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ReturnedSubject>> Get()
        {
            var subjects = subjectRepository.GetAll()
                ?.Select(s => (ReturnedSubject) s);

            if (subjects == null)
            {
                return NotFound();
            }

            return new ObjectResult(subjects);
        }
        
        [HttpGet("{id:int}")]
        public ActionResult<ReturnedSubject> Get(uint id)
        {
            var subjects = subjectRepository.GetById(id);
            
            if (subjects == null)
            {
                return NotFound();
            }

            return new ObjectResult((ReturnedSubject)  subjects);
        }
        
        [HttpPost]
        public ActionResult<IEnumerable<ReturnedSubject>> AddSubject()
        {
            var subjects = subjectRepository.GetAll()
                ?.Select(s => (ReturnedSubject) s);

            if (subjects == null)
            {
                return NotFound();
            }

            return new ObjectResult(subjects);
        }
    }
}