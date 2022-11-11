using LinQExample.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LinQExample
{
    public class LinQFunction
    {

        public LinQFunction()
        {
        }

        public void GetProductIEnumerable()
        {
            var _context = new ShopOnline_ShoesContext();
            IEnumerable<ProductDetail> products = _context.ProductDetails.Where(pro => pro.Name.Contains("A"));

            var product1 = products.Take(3).ToList();

            var product2 = products.Count();
        }

        public void GetProductIQueryable()
        {
            var _context = new ShopOnline_ShoesContext();
            IQueryable<ProductDetail> products = _context.ProductDetails.Where(pro => pro.Name.Contains("A"));

            var product1 = products.Take(3).ToList();

            var product2 = products.Count();
        }

        public void GetProductFirst()
        {
            var _context = new ShopOnline_ShoesContext();
            var product =  _context.ProductDetails.Where(x => x.Id == 0).First();
            Console.WriteLine(product);
        }

        public void GetProductFirstOrDefault()
        {
            var _context = new ShopOnline_ShoesContext();
            var product = _context.ProductDetails.Where(x => x.Id == 2).FirstOrDefault();
            //_context.ProductDetails = null;
            //var product = _context.ProductDetails?.Where(x => x.Id == 0).FirstOrDefault();
            Console.WriteLine(product);
        }

        public void GetCustomerSingle()
        {
            var _context = new ShopOnline_ShoesContext();
            var customer = _context.Customers.Where(x => x.TypeAcc == 2).Single();
        }

        public void GetCustomerSingleOrDefault()
        {
            var _context = new ShopOnline_ShoesContext();
            var customer = _context.Customers.Where(x => x.Id == 0).SingleOrDefault();
        }

        public void GetProductTypeQuerySynctax()
        {
            var _context = new ShopOnline_ShoesContext();

            var productType = from p in _context.ProductTypes
                              where p.Name.Contains("U")
                              select p;
                             
        }

        public void GetStaff()
        {
            var _context = new ShopOnline_ShoesContext();
            var staff = _context.Staff.Where(x => x.TypeAcc == 2).Single();
        }

        public void GetProducts()
        {
            var _context = new ShopOnline_ShoesContext();
            Expression<Func<ProductDetail, bool>> expression = product => product.IdProductType == 1;

            var productJordan = _context.ProductDetails.Where(expression).ToList();

            bool isDelete = false;
            //var productJordan = _context.ProductDetails.WhereIf(isDelete, x => x.Status == 1).ToList();
        }


        public void GetListProducts()
        {
            var _context = new ShopOnline_ShoesContext();
            var product01s = _context.Products.Where(x=>x.IsDeleted == false).Select(x => new ProductModel
            {
               Id = x.Id,
               Name = x.Name,
               Quantity = x.Quantity, 
               Size = x.Size,
               CreatorUserId = x.CreatorUserId,
            }).ToList();

            foreach (var product01 in product01s)
            {
                product01.CreatorUserName = _context.Staff.Where(x => x.Id == product01.CreatorUserId).Select(x => x.FullName).FirstOrDefault();
            }

            var product02s =  _context.Products.Where(x => x.IsDeleted == false).Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Size = x.Size,
                CreatorUserId = x.CreatorUserId,
            });

            var user = _context.Staff.Where(x => product02s.Any(y => y.CreatorUserId == x.Id)).Select(x => new
            {
                Id = x.Id,
                FullName = x.FullName,
            }).ToList();

            foreach (var product02 in product02s)
            {
                product02.CreatorUserName = user.Where(x => x.Id == product02.CreatorUserId).Select(x => x.FullName).FirstOrDefault();
            }
        }

        public void GetListProductsJoin()
        {
            var _context = new ShopOnline_ShoesContext();
            var products = _context.Products.Join(_context.Staff, pro => pro.CreatorUserId, s => s.Id, (pro, s) => new
            {
                s.FullName,
                pro.Id,
                pro.Name,
                pro.Quantity,
                pro.Size,
                pro.CreatorUserId,
            }).Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Quantity = x.Quantity,
                Size = x.Size,
                CreatorUserId = x.CreatorUserId,
                CreatorUserName = x.FullName,
            }).ToList();

            Console.WriteLine(products);
        }

    }

}