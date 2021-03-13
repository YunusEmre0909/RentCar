using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _branService;

        public BrandsController(IBrandService branService)
        {
            _branService = branService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _branService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _branService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var result = _branService.Add(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(Brand brand)
        {
            var result = _branService.Delete(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            var result = _branService.Update(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
    }
}
