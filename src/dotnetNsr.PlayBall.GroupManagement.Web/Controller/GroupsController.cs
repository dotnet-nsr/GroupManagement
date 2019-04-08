using dotnetNsr.PlayBall.GroupManagement.Business.Services;
using dotnetNsr.PlayBall.GroupManagement.Web.Mappings;
using dotnetNsr.PlayBall.GroupManagement.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnetNsr.PlayBall.GroupManagement.Web.Controller
{
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
        public IActionResult Index()
        {
            return View(_groupsService.GetAll().ToViewModel());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = _groupsService.GetById(id);
            
            if (group == null)
            {
                return NotFound();
            }

            return View(group.ToViewModel());
        }

        [HttpPost]
        [Route("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model)
        {
            var group = _groupsService.Update(model.ToServiceModel());

            if (group == null)
            {
                return NotFound();
            }

            group.Name = model.Name;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateGroup(GroupViewModel model)
        {
            _groupsService.Add(model.ToServiceModel());

            return RedirectToAction("Index");
        }
        
    }
}