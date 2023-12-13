using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MeetingLogger.Data
{
    public partial class ApplicationDbContext
    {
        private IApplicationDbContextProcedures _procedures;

        public virtual IApplicationDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ApplicationDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IApplicationDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
        }
    }

    public partial class ApplicationDbContextProcedures : IApplicationDbContextProcedures
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextProcedures(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> Meeting_Minutes_Details_Save_SPAsync(int? MeetingId, int? ProductId, int? Quantity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "MeetingId",
                    Value = MeetingId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "ProductId",
                    Value = ProductId ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "Quantity",
                    Value = Quantity ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[Meeting_Minutes_Details_Save_SP] @MeetingId, @ProductId, @Quantity", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> Meeting_Minutes_Master_Save_SPAsync(string CustomerType, string CustomerName, DateOnly? MeetingDate, TimeOnly? MeetingTime, string MeetingPlace, string AttendsFromClientSide, string AttendsFromHostSide, string MeetingAgenda, string MeetingDiscussion, string MeetingDecision, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "CustomerType",
                    Size = 20,
                    Value = CustomerType ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "CustomerName",
                    Size = 100,
                    Value = CustomerName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingDate",
                    Value = MeetingDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Date,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingTime",
                    Scale = 7,
                    Value = MeetingTime ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Time,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingPlace",
                    Size = 100,
                    Value = MeetingPlace ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "AttendsFromClientSide",
                    Size = 100,
                    Value = AttendsFromClientSide ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "AttendsFromHostSide",
                    Size = 100,
                    Value = AttendsFromHostSide ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingAgenda",
                    Size = -1,
                    Value = MeetingAgenda ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingDiscussion",
                    Size = -1,
                    Value = MeetingDiscussion ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "MeetingDecision",
                    Size = -1,
                    Value = MeetingDecision ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[Meeting_Minutes_Master_Save_SP] @CustomerType, @CustomerName, @MeetingDate, @MeetingTime, @MeetingPlace, @AttendsFromClientSide, @AttendsFromHostSide, @MeetingAgenda, @MeetingDiscussion, @MeetingDecision", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
