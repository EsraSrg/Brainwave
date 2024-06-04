using BrainWave.DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DataAccessLayer.Repostories
{
    public class ProjectRepostory
    {
        private readonly Context _context;

        public ProjectRepostory(Context context)
        {
            _context = context;
        }

        public async Task DoDatabaseOperationsAsync()
        {
            var connection = _context.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    // Parametre eklemek gerekiyorsa, aşağıdaki gibi ekleyebilirsin:
                    // command.Parameters.Add(new SqlParameter("@ParameterName", parameterValue));

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Veritabanı işlemi sırasında bir hata oluştu.", ex);
            }
            finally
            {
                await connection.CloseAsync();
            }
        }
    }
}

