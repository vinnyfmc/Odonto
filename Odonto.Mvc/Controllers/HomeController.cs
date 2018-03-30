using AutoMapper;
using Odonto.Domain.Entities;
using Odonto.Mvc.Mappers;
using Odonto.Mvc.Models;
using Odonto.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Odonto.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unit = new UnitOfWork();
        private readonly IMapper mapper;

        public HomeController()
        {
            mapper = AutoMapperConfig.Mapper;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}