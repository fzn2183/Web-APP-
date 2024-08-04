using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Registration.Module.moodule.Repository;
using Oqtane.Controllers;
using System.Net;

namespace Registration.Module.moodule.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class mooduleController : ModuleControllerBase
    {
        private readonly ImooduleRepository _mooduleRepository;

        public mooduleController(ImooduleRepository mooduleRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _mooduleRepository = mooduleRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.moodule> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _mooduleRepository.Getmoodules(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized moodule Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.moodule Get(int id)
        {
            Models.moodule moodule = _mooduleRepository.Getmoodule(id);
            if (moodule != null && IsAuthorizedEntityId(EntityNames.Module, moodule.ModuleId))
            {
                return moodule;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized moodule Get Attempt {mooduleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.moodule Post([FromBody] Models.moodule moodule)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, moodule.ModuleId))
            {
                moodule = _mooduleRepository.Addmoodule(moodule);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "moodule Added {moodule}", moodule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized moodule Post Attempt {moodule}", moodule);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                moodule = null;
            }
            return moodule;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.moodule Put(int id, [FromBody] Models.moodule moodule)
        {
            if (ModelState.IsValid && moodule.mooduleId == id && IsAuthorizedEntityId(EntityNames.Module, moodule.ModuleId) && _mooduleRepository.Getmoodule(moodule.mooduleId, false) != null)
            {
                moodule = _mooduleRepository.Updatemoodule(moodule);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "moodule Updated {moodule}", moodule);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized moodule Put Attempt {moodule}", moodule);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                moodule = null;
            }
            return moodule;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.moodule moodule = _mooduleRepository.Getmoodule(id);
            if (moodule != null && IsAuthorizedEntityId(EntityNames.Module, moodule.ModuleId))
            {
                _mooduleRepository.Deletemoodule(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "moodule Deleted {mooduleId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized moodule Delete Attempt {mooduleId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
