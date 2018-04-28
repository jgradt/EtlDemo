using Rhino.Etl.Core.Operations;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EtlDemoNetStandard.Etl
{
    public class BulkInsertToCustomerTableOperation : SqlBulkInsertOperation
    {
        private string _connectionStringName;

        public BulkInsertToCustomerTableOperation(string connectionStringName) : base(connectionStringName, "Customer")
        {
            _connectionStringName = connectionStringName;

            // truncate table before bulk inserting new rows
            TruncateTable();
        }

        private void TruncateTable()
        {
            using (SqlConnection connection = new SqlConnection(
               ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString))
            {
                var sql = @"
                    IF (EXISTS (SELECT * 
                                     FROM INFORMATION_SCHEMA.TABLES 
                                     WHERE TABLE_SCHEMA = 'dbo' 
                                     AND  TABLE_NAME = 'Customer'))
                    BEGIN
                        TRUNCATE TABLE dbo.Customer
                    END
                ";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        protected override void PrepareSchema()
        {
            Schema.Add("Id", typeof(string));
            Schema.Add("FirstName", typeof(string));
            Schema.Add("LastName", typeof(string));
            Schema.Add("Ssn", typeof(string));
            Schema.Add("DateOfBirth", typeof(DateTime));
            Schema.Add("Address", typeof(string));
            Schema.Add("City", typeof(string));
            Schema.Add("State", typeof(string));
            Schema.Add("Zip", typeof(string));
            Schema.Add("MobilePhoneAreaCode", typeof(string));
            Schema.Add("MobilePhone", typeof(string));
            Schema.Add("HomePhoneAreaCode", typeof(string));
            Schema.Add("HomePhone", typeof(string));
        }
    }
}
