using Microsoft.AspNetCore.Mvc;
using projAPIDapper.Models;
using projAPIDapper.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace projAPIDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresenceBooksController:ControllerBase
    {
        private readonly IRepository repository;
        public PresenceBooksController(IRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public virtual ActionResult Get()
        {
            var get = repository.Get();
            if (get.Count() != 0)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = get.Count() + " Data Ditemukan", Data = get });
            }
            else
            {
                return StatusCode(404, new { status = HttpStatusCode.NotFound, message = get.Count() + " Data Ditemukan", Data = get });
            }
        }
        [HttpPost]
        public virtual ActionResult Insert(PresenceBook presenceBook)
        {
            var insert = repository.Insert(presenceBook);
            if (insert >= 1)
            {
                return StatusCode(200, new { status = HttpStatusCode.OK, message = "Data Berhasil Dimasukkan", Data = insert });
            }
            else
            {
                return StatusCode(500, new { status = HttpStatusCode.InternalServerError, message = "Gagal Memasukkan Data", Data = insert });
            }
        }
    }
}
