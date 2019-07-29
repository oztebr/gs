using goldStore.Areas.Panel.Models;
using goldStore.Areas.Panel.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace goldStore.Areas.Panel.Controllers
{
    public class ProductRepository : IRepository<product>
    {
        private goldstoreEntities _context;
        public ProductRepository(goldstoreEntities Context)
        {
            this._context = Context;
        }
        public void Delete(int id)
        {
            productImage img = _context.productImage.Find(id);
            if(img !=null)
            {
                _context.productImage.Remove(img);
                _context.SaveChanges();
            }
        }
        public void Delete(product model)
        {
            _context.product.Remove(model);
            _context.SaveChanges();
        }

        public product Get(int id)
        {
            return _context.product.Find(id);
        }

        public List<product> GetAll()
        {
            return _context.product.ToList();
        }

        public void Save(product model)
        {
            _context.product.Add(model);
            _context.SaveChanges();
        }

        public void Save(productImage model)
        {
            _context.productImage.Add(model);
            _context.SaveChanges();
        }

        public void Update(product model)
        {
            product old = Get(model.productId);
            _context.Entry(old).State = EntityState.Detached;
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public List<category> GetCategories()
        {
            return _context.category.ToList();
        }
        public List<brand> GetBrands()
        {
            return _context.brand.ToList();
        }
    }
}