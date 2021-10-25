using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecruitmentTask.Models;
using RecruitmentTask.Models.Dto;
using RecruitmentTask.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitmentTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrderController(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_orderRepository.GetAll());
        }

        [HttpGet, Route("{id}")]
        public IActionResult Get(int id)
        {
            var result = _orderRepository.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut, Route("{id}")]
        public IActionResult Put(int id, OrderDto order)
        {
            var result = _orderRepository.GetById(id);
            if (result == null || !ModelState.IsValid)
                return BadRequest();
            var mappedOrder = _mapper.Map(order, result);
            try
            {
                _orderRepository.Update(mappedOrder);

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                StatusCode(500);
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = _mapper.Map<Order>(order);
            try
            {
                _orderRepository.Create(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                StatusCode(500);
            }
            return NoContent();
        }
    }
}
