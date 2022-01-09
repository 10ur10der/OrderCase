using Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IProductService _productService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, IProductService productService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _productService = productService;
            _logger = logger;
        }


        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _orderService.GetList();

            if (result.Status)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyId/{customerOrderNo}")]
        public IActionResult GetOrderDetailsById(string customerOrderNo)
        {
            var result = _orderService.GetById(customerOrderNo);

            if (result.Status)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "addOrder")]
        public IActionResult Add(Order order)
        {
            IResult result;
            try
            {
                var prod = _productService.GetById(order.ProductCode);

                if (prod.Data == null)
                {
                    var newProd = new Product()
                    {
                        ProductCode = order.ProductCode,
                        ProductName = order.ProductName
                    };
                    _productService.Add(newProd);
                    order.Status = StatusEnum.OrderTaken;
                    result = _orderService.Add(order);
                    _logger.LogInformation(result.Message);
                    return Ok(result);
                }
                else
                {
                    result = _orderService.Add(order);
                    _logger.LogInformation(result.Message);
                    return Ok(result);

                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return BadRequest(ex.Message);

            }
        }

        [HttpPost(template: "status")]
        public IActionResult UpdateStatus(OrderStatus order)
        {

            try
            {
                var orderItem = _orderService.GetById(order.CustomerOrderNo);

                orderItem.Data.Status = (StatusEnum)order.StatusValue;
                orderItem.Data.ChangeDate = DateTime.Now;  

                var result = _orderService.Update(orderItem.Data);

                if (result.Status)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }







    }
}
