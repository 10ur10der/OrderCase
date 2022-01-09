using Core.Utilities.Results;
using DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.OrderResult;
namespace Business
{
    public class OrderManager : IOrderService
    {
        private IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;          
        }

        public IResult Add(Order order)
        {
            try
            {
                _orderDal.Add(order);
                var result = new SuccessOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID, 
                    Message = Messages.OrderAdded,
                    
                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ErrorOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID,
                    Message = ex.Message,

                };
                return result;
            }
           
        }

        public IResult Delete(Order order)
        {
            try
            {
                _orderDal.Delete(order);
                var result = new SuccessOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID,
                    Message = Messages.OrderAdded,

                };
                return result;
            }
            catch (Exception ex)
            {
                var result = new ErrorOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID,
                    Message = ex.Message,

                };
                return result;
            }
            
        }

        public IDataResult<Order> GetById(string customerOrderNo)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(filter: p => p.CustomerOrderNo == customerOrderNo));
        }

        public IDataResult<List<Order>> GetList()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetList().ToList());
        }

        public IDataResult<List<Order>> GetPageToList(int itemsPerPage, int page)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetPageList(itemsPerPage, page).ToList());
        }

        public IResult Update(Order order)
        {
            try
            {
                _orderDal.Update(order);
                var result = new SuccessOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID,
                    Message = Messages.OrderUpdated,

                };
                return result;
            }
            catch (Exception ex)
            {

                var result = new ErrorOrderResult()
                {
                    CustomerOrderNo = order.CustomerOrderNo,
                    SystemOrderNo = order.ID,
                    Message = ex.Message,

                };
                return result;
            }
          
           
        }
    }
}
