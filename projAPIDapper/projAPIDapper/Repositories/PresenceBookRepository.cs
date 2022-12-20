using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using projAPIDapper.Context;
using projAPIDapper.Models;
using projAPIDapper.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace projAPIDapper.Repositories
{
    public class PresenceBookRepository : IRepository
    {
        public IConfiguration _configuration;
        private readonly myContext context;
        public PresenceBookRepository(IConfiguration configuration, myContext context)
        {
            _configuration = configuration;
            this.context = context;
        }
        DynamicParameters parameters = new DynamicParameters();
        public int Delete(int Id)
        {
            var find = context.PresenceBooks.Find(Id);
            if (find != null)
            {
                context.PresenceBooks.Remove(find);
                return context.SaveChanges();
            }
            return 0;
        }

        public IEnumerable<PresenceBook> Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var spName = "SP_GetAllPB";
                var pb = connection.Query<PresenceBook>(spName, commandType: CommandType.StoredProcedure);
                return pb;
            }
        }

        public PresenceBook Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(PresenceBook presenceBook)
        {
            using(SqlConnection connection=new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var procInsName = "SP_Insert";
                parameters.Add("@Name", presenceBook.Name);
                var insert = connection.Execute(procInsName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Update(PresenceBook presenceBook)
        {
            context.Entry(presenceBook).State = EntityState.Modified;
            return context.SaveChanges();
        }
    }
}
