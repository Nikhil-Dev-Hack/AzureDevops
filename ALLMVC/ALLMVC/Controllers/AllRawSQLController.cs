using ALLMVC.Data;
using ALLMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace ALLMVC.Controllers
{
    public class AllRawSQLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllRawSQLController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> RawSqlQuery(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            string Query = "SELECT * FROM Employee WHERE Id = {0}";
            var employees = await _context.Employee
                .FromSqlRaw(Query, Id)
                .Include(d => d.Department)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            //Another way of simpleRawQuery
            //var employees = await _context.Employee.FromSqlRaw(Query, Id).FirstOrDefaultAsync();

            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        public async Task<IActionResult> ComplexSqlQuery()
        {
            List<EmpDep> emps = new List<EmpDep>();
            var conn = _context.Database.GetDbConnection();
            try
            {
                await conn.OpenAsync();
                using (var command = conn.CreateCommand())
                {
                    //var query = "SELECT E.Name,E.Email,E.DepartmentId,D.Name,D.Location" 
                    //    +"FROM Employee E , Department D"+ "WHERE E.DepartmentId = D.Id ";
                    var query = "SELECT E.Name,E.Email,E.DepartmentId,D.Name,D.[Location]"
                        +"FROM Employee E , Department D WHERE E.DepartmentId = D.Id";
                    command.CommandText = query;
                    DbDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var row = new EmpDep
                            {
                                EmpName = reader.GetString(0),
                                Email =reader.GetString(1),
                                DepartmentId = reader.GetInt32(2),
                                Name = reader.GetString(3),
                                Location =reader.GetString(4)
                            };
                            emps.Add(row);
                        }
                    }
                    reader.Dispose();
                }
            }
            finally 
            {
                conn.Close();
                
            }
            return View(emps);
        }
         
    }
}
