using Project_DAW.Models.DTOs;
using Project_DAW.Models;
using Project_DAW.Repositories.CustomerRepository;
using Project_DAW.Repositories.OrderRepository;
using AutoMapper;
using Project_DAW.Repositories.UnitOfWork;

namespace Project_DAW.Services.OrderService
{
    public class OrderService : IOrderService
    {
        //public IOrderRepository _orderRepository;
        public ICustomerRepository _customerRepository;
        public IMapper _mapper;
        public IUnitOfWork _unitOfWork;
        public OrderService( IMapper mapper, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            //_orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(OrderDTO order)
        {
            var _customer = _unitOfWork.customerRepository.GetCustomerByEmail(order.CustomerEmail);
            //var _order = _mapper.Map<Order>(order);
            var _order = new Order
            {
                BillingAddress = order.BillingAddress,
                ShippingAddress = order.ShippingAddress,
                PaymentMethod = order.PaymentMethod,
                TotalCost = order.TotalCost,
                Customer = _customer,
                CustomerID = _customer.Id
            };
            await _unitOfWork.orderRepository.CreateAsync(_order);
            await _unitOfWork.orderRepository.SaveAsync();
        }
        public async Task Delete(Guid id)
        {
            var order = await _unitOfWork.orderRepository.FindByIdAsync(id);
            _unitOfWork.orderRepository.Delete(order);
            await _unitOfWork.orderRepository.SaveAsync();
        }
        public async Task<List<Order>> GetAll()
        {
            return await _unitOfWork.orderRepository.GetAll();
        }

        public IQueryable<PaymentDTO> GetAllPayment()
        {
            return _unitOfWork.orderRepository.GetOrdersByPaymentMethod();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _unitOfWork.orderRepository.FindByIdAsync(id);
        }
        public async Task<Order?> Update(Guid id, OrderDTO order)
        {
            var ord = await _unitOfWork.orderRepository.FindByIdAsync(id);

            if (ord == null)
                return null;

            ord.PaymentMethod = order.PaymentMethod;
            ord.ShippingAddress = order.ShippingAddress;
            ord.BillingAddress = order.BillingAddress;
            ord.TotalCost = order.TotalCost;

            await _unitOfWork.orderRepository.SaveAsync();
            return ord;
        }
    }
}
