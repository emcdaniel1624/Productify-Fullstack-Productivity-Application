using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoSqlProvider.Factory;
using NoSqlProvider.Providers;
using NoSqlProvider.Entity;
using Productify.API.Data.Provider;
using Productify.API.Models;

namespace Productify.API.Controllers
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectsController : ApiControllerBase
    {
        private ProviderFactory<ProductifyProvider> _providerFactory;

        public ProjectsController(ProviderFactory<ProductifyProvider> providerFactory)
        {
            _providerFactory = providerFactory;
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var provider = _providerFactory.CreateProvider();
            var projects = provider.Projects;
            return Ok(projects);
        }

        //[HttpGet]
        //public IActionResult GetProject()
        //{
        //    var provider = _providerFactory.CreateProvider();
        //    var projects = provider.GetAll<Project>();
        //    return Ok(projects.ToList());
        //}

        [HttpPost]
        public IActionResult AddProject(Project project)
        {
            var provider = _providerFactory.CreateProvider();
            provider.Create<Project>(project);
            return Ok(project);
        }

        [HttpDelete]
        public IActionResult DeleteProject(string id)
        {
            var provider = _providerFactory.CreateProvider();
            provider.Delete<Project>(id);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult UpdateProject(Project project)
        {
            var provider = _providerFactory.CreateProvider();
            provider.Update(project.Id, project);
            return Ok(project);
        }

    }
}
