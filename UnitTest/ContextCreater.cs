using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitTest
{
    public class ContextCreater
    {
        public static EShopContext CreateContext([CallerMemberName] string dbname = "")
        {
            DbContextOptionsBuilder<EShopContext> optionsBuilder = new DbContextOptionsBuilder<EShopContext>();
            optionsBuilder.UseInMemoryDatabase(dbname);
            optionsBuilder.EnableSensitiveDataLogging();
            return new EShopContext(optionsBuilder.Options);
        }
    }
}
