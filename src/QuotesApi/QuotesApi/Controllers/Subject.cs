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
        private readonly ISubjectRepository subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        /// <summary>
        /// Get all subjects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<ReturnedSubject>> Get()
        {
            var subjects = subjectRepository.GetAll()
                ?.Select(s => (ReturnedSubject) s)
                .OrderBy(s => s.Id);

            if (subjects == null) return NotFound();

            return new ObjectResult(subjects);
        }

        /// <summary>
        /// Get 1 subject with certain Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<ReturnedSubject> Get(int id)
        {
            var subjects = subjectRepository.GetById(id);

            if (subjects == null) return NotFound();

            return new ObjectResult((ReturnedSubject) subjects);
        }

        /// <summary>
        /// Add subject
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IEnumerable<ReturnedSubject>> AddSubject()
        {
            var subjects = subjectRepository.GetAll()
                ?.Select(s => (ReturnedSubject) s);

            if (subjects == null) return NotFound();

            return new ObjectResult(subjects);
        }
    }
}