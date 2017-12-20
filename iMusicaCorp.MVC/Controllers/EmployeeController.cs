using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using iMusicaCorp.Application.Interfaces;
using iMusicaCorp.Application.ViewModels;
using iMusicaCorp.Infra.CrossCutting.DataTransferObject;

namespace iMusicaCorp.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IRoleAppService _roleAppService;


        public EmployeeController(IEmployeeAppService employeeAppService, IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
            _employeeAppService = employeeAppService;
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Session.Remove("DEPENDENT");
            ViewBag.role = new SelectList(_roleAppService.GetAll(), "RoleId", "Name");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["DEPENDENT"] != null)
                    {
                        var deps = (List<DependentDto>)Session["DEPENDENT"];

                        foreach (var depDto in deps)
                        {
                            var dependente = new DependentViewModel();
                            dependente.Name = depDto.Nome;

                            model.Dependents.Add(dependente);
                        }
                    }

                    ViewBag.role = new SelectList(_roleAppService.GetAll(), "RoleId", "Name", model.RoleId);

                    _employeeAppService.Add(model);

                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.role = new SelectList(_roleAppService.GetAll(), "RoleId", "Name");
                }

                return View(model);

            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _employeeAppService.GetById(id);

            ViewBag.role = new SelectList(_roleAppService.GetAll(), "RoleId", "Name", model.RoleId);

            var depentents = model.Dependents.Select(dep => new DependentDto
            {
                Id = dep.DependentId,
                Nome = dep.Name
            }).ToList();

            ViewBag.Dependent = depentents;
            Session.Add("DEPENDENT", depentents);


            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["DEPENDENT"] != null)
                    {
                        var deps = (List<DependentDto>)Session["DEPENDENT"];

                        foreach (var depDto in deps)
                        {
                            var dependente = new DependentViewModel();
                            dependente.Name = depDto.Nome;
                            dependente.DependentId = depDto.Id;
                            dependente.EmployeeId = model.EmployeeId;
                            dependente.Employee = model;
                            dependente.Excluido = depDto.Excluido;

                            model.Dependents.Add(dependente);
                        }
                    }

                    _employeeAppService.Update(model);

                    return RedirectToAction("Index");
                }


                return View(model);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _employeeAppService.GetById(id);
            return View(model);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(EmployeeViewModel model)
        {
            try
            {
                var employee = _employeeAppService.GetById(model.EmployeeId);

                _employeeAppService.Remove(employee);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        [HttpGet]
        public JsonResult GetGridData(string search, string order, int? limit, int? offset)
        {
            var employeeList = _employeeAppService.GetGridData(search, order, limit, offset);

            var result = (from e in employeeList
                          select new
                          {
                              Id = e.EmployeeId,
                              Nome = e.Name,
                              Sexo = e.Gender == "M" ? "Masculino" : "Feminino",
                              DataNascimento = e.Birth.ToShortDateString(),
                              Cargo = e.Role.Name,
                              QtdDependentes = e.Dependents.Count,
                              e.Rows
                          }).ToList();

            JsonResult jsonResult = Json(new
            {
                total = result.Any() ? result.FirstOrDefault().Rows : 0,
                rows = result
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public JsonResult AddDependents(string nome)
        {
            var dependentes = new List<DependentDto>();

            if (Session["DEPENDENT"] != null)
            {
                dependentes = (List<DependentDto>)Session["DEPENDENT"];
            }

            var dep = new DependentDto
            {
                Nome = nome
            };

            dependentes.Add(dep);

            Session.Add("DEPENDENT", dependentes);

            return Json(dependentes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateDependents(List<DependentDto> dtos)
        {
            var dependentes = new List<DependentDto>();

            if (Session["DEPENDENT"] != null)
            {
                dependentes = (List<DependentDto>)Session["DEPENDENT"];
            }

            var dep = dependentes.FindAll(x => !x.Excluido).ToList();

            foreach (var depentente in dep)
            {
                dependentes.Remove(depentente);
            }

            if (dtos != null)
            {
                dependentes.AddRange(dtos);
            }

            Session.Add("DEPENDENT", dependentes);

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RemoveDependents(string[] nomes)
        {
            var dependentes = new List<DependentDto>();

            if (Session["DEPENDENT"] != null)
            {
                dependentes = (List<DependentDto>)Session["DEPENDENT"];
            }

            var dep = dependentes.FindAll(x => nomes.Contains(x.Nome)).ToList();

            foreach (var depentente in dep)
            {
                dependentes.Find(x => x.Nome == depentente.Nome).Excluido = true;
                //dependentes.Remove(depentente);
            }

            Session.Add("DEPENDENT", dependentes);

            return Json(dependentes.Where(x => !x.Excluido), JsonRequestBehavior.AllowGet);

        }
        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                _employeeAppService.Dispose();
                _roleAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
