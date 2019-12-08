using System.Data.Entity;
using Bibuddy.Business.Abstract;
namespace Bibuddy.Business.Concrete
{
    public class UnitOfWork<TContext>: IUnitOfWork 
        where  TContext:DbContext,new() 
    {
        private readonly TContext _context;
        public UnitOfWork(TContext context)
        {
            _context = context;
        }
        public void CompleteTask()
        {
            _context.SaveChanges();
        }
    }
}