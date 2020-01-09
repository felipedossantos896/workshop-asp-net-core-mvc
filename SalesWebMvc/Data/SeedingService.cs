using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }
            else
            {
                Department department1 = new Department(1, "Computers");
                Department department2 = new Department(2, "Eletronics");
                Department department3 = new Department(3, "Fashion");
                Department department4 = new Department(4, "Books");

                Seller seller0 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, department1);
                Seller seller1 = new Seller(2, "João Mesquita", "joao@gmail.com", new DateTime(1987, 5, 17), 1500.0, department2);
                Seller seller2 = new Seller(3, "Brian Jones", "brian@gmail.com", new DateTime(1990, 8, 15), 3000.0, department4);
                Seller seller3 = new Seller(4, "Julius Osha", "julius@gmail.com", new DateTime(1974, 3, 21), 7000.0, department1);
                Seller seller4 = new Seller(5, "Venat Venus", "venat@gmail.com", new DateTime(1999, 4, 22), 4500.0, department3);

                SalesRecord salesRecord0 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, seller0);
                SalesRecord salesRecord1 = new SalesRecord(2, new DateTime(2018, 08, 19), 1000.0, SaleStatus.Pending, seller1);
                SalesRecord salesRecord2 = new SalesRecord(3, new DateTime(2018, 03, 10), 7000.0, SaleStatus.Canceled, seller4);
                SalesRecord salesRecord3 = new SalesRecord(4, new DateTime(2018, 05, 13), 2000.0, SaleStatus.Canceled, seller3);
                SalesRecord salesRecord4 = new SalesRecord(5, new DateTime(2018, 01, 18), 4000.0, SaleStatus.Billed, seller2);

                _context.Department.AddRange(department1, department2, department3, department4);
                _context.Seller.AddRange(seller0, seller1, seller2, seller3, seller4);
                _context.SalesRecord.AddRange(salesRecord0, salesRecord1, salesRecord2, salesRecord3, salesRecord4);

                _context.SaveChanges();
            }
        }
    }
}
