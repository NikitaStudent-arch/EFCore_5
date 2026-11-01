using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Shop
{
    public class ServiceShop
    {
        private readonly ShopDbContext _context;
        public ServiceShop(ShopDbContext context)
        {
            _context = context;
        }
        // Создание нового продукта
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        // Получение всех продуктов
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products;
        }
        // Создание нового заказа
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
        // Получение всех заказов
        public IQueryable<Order> GetAllOrders()
        {
            return _context.Orders;
        }
        // Создание нового клиента
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        // Получение всех клиентов
        public IQueryable<Client> GetAllClients()
        {
            return _context.Clients;
        }
        // Получение всех продуктов для определенного заказа
        public IQueryable<Product> GetProductsForOrder(int orderId)
        {
            return _context.Orders
            .Where(o => o.Id == orderId)
            .SelectMany(o => o.Products);
        }
        // Получение всех заказов с информацией о продуктах и клиентах
        public IQueryable<Order> GetAllOrdersWithDetails()
        {
            return _context.Orders
            .Include(o => o.Products)
            .Include(o => o.Client);
        }
    }
}