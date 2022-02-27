using Microsoft.EntityFrameworkCore;
using System;

namespace PruebaPersonal.Data
{
    public class ContextBase : IDisposable
    {
        public SeguroContext _context;       

        public void GetContexto()
        {
            var contextOptions = new DbContextOptionsBuilder<SeguroContext>()
                                    .UseSqlServer("Server=ANDRES-PC\\SQLEXPRESS;Database=Polizas;Trusted_Connection=True;")
                                    .Options;

            _context = new SeguroContext(contextOptions);
        }

        public void Dispose()
        {
            this._context = null;
        }
    }
}
