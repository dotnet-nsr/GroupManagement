using System;
using System.Threading;
using System.Threading.Tasks;
using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using dotnetNsr.PlayBall.GroupManagement.Web.Demo.Filters;
using dotnetNsr.PlayBall.GroupManagement.Web.Mappings;
using dotnetNsr.PlayBall.GroupManagement.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnetNsr.PlayBall.GroupManagement.Web.Controller
{
    [ServiceFilter(typeof(DemoExceptionFilter))]
    [Route("groups")]
    public class GroupsController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly IGroupsService _groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            _groupsService = groupsService;
        }
        
         
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result =  await _groupsService.GetAll(cancellationToken);
            return View(result.ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
        {
            var group = await _groupsService.GetById(id, cancellationToken);
            
            if (group == null)
            {
                return NotFound();
            }

            return View(group.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, GroupViewModel model, CancellationToken cancellationToken)
        {
            var group = await _groupsService.Update(model.ToServiceModel(), cancellationToken);

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateGroup(GroupViewModel model, CancellationToken cancellationToken)
        {
            await _groupsService.Add(model.ToServiceModel(), cancellationToken) ;

            return RedirectToAction("Index");
        }
        
    }
}