using System.Data.Entity;
using WebApp1.Data;
using WebApp1.Models;
using WebApp1.Repository;

namespace WebApp1.UnitOfWork
{
    public class UnitOfWorkApp : DbContext
    {
        ContextApp context = new ContextApp();
        Repository<Produts> productRepository;

        public Repository<Produts> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new Repository<Produts>(context);

                return productRepository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }

    }
}