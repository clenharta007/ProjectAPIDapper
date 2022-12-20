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
            /*var find = context.PresenceBooks.Find(Id);
            if (find != null)
            {
                context.PresenceBooks.Remove(find);
                return context.SaveChanges();
            }
            return 0;*/
            using(SqlConnection connection=new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var procDelName = "SP_Delete";
                parameters.Add("@Id", Id);
                var delete = connection.Execute(procDelName, parameters, commandType: CommandType.StoredProcedure);
                return delete;
            }
        }

        public IEnumerable<PresenceBook> Get()
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var spName = "SP_GetAllPBook";
                var pb = connection.Query<PresenceBook>(spName, commandType: CommandType.StoredProcedure);
                return pb;
            }
        }

        public IEnumerable<PresenceBook> Get(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var spGetOneName = "SP_GetOneDataPBook";
                parameters.Add("@id_onedata", Id);
                var getPBOne = connection.Query<PresenceBook>(spGetOneName, parameters, commandType: CommandType.StoredProcedure);
                return getPBOne;
            }
            /*return context.PresenceBooks.Find(Id);*/
        }

        public int Insert(PresenceBook presenceBook)
        {
            using(SqlConnection connection=new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var procInsName = "SP_Insert";
                parameters.Add("@Name", presenceBook.Name);
                parameters.Add("@Phone", presenceBook.Phone);
                parameters.Add("@Email", presenceBook.Email);
                parameters.Add("@Address", presenceBook.Address);
                parameters.Add("@Provinsi", presenceBook.Provinsi);
                parameters.Add("@Kota", presenceBook.Kota);
                parameters.Add("@Kecamatan", presenceBook.Kecamatan);
                parameters.Add("@Kelurahan", presenceBook.Kelurahan);
                parameters.Add("@Kodepos", presenceBook.Kodepos);
                parameters.Add("@dateadded", presenceBook.DateAdded);
                var insert = connection.Execute(procInsName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Update(PresenceBook presenceBook)
        {
            /*context.Entry(presenceBook).State = EntityState.Modified;
            return context.SaveChanges();*/
            using(SqlConnection connection=new SqlConnection(_configuration["ConnectionStrings:API"]))
            {
                var procUpName = "SP_UpdatePBook";
                parameters.Add("@Id", presenceBook.Id);
                parameters.Add("@Name", presenceBook.Name);
                parameters.Add("@Phone", presenceBook.Phone);
                parameters.Add("@Email", presenceBook.Email);
                parameters.Add("@Address", presenceBook.Address);
                parameters.Add("@Provinsi", presenceBook.Provinsi);
                parameters.Add("@Kota", presenceBook.Kota);
                parameters.Add("@Kecamatan", presenceBook.Kecamatan);
                parameters.Add("@Kelurahan", presenceBook.Kelurahan);
                parameters.Add("@Kodepos", presenceBook.Kodepos);
                parameters.Add("@dateadded", presenceBook.DateAdded);
                var update = connection.Execute(procUpName,parameters,commandType: CommandType.StoredProcedure);
                return update;

            }
        }
    }
}
