using Rhino.Etl.Core.ConventionOperations;

namespace EtlDemo.Etl
{
    public class BatchInsertToCustomerTableOperation : ConventionSqlBatchOperation
    {
        public BatchInsertToCustomerTableOperation(string connString) : base(connString)
        {
            Command = @"INSERT INTO dbo.Customer 
                        (Id, 
                        FirstName, 
                        LastName, 
                        Ssn, 
                        DateOfBirth, 
                        Address, 
                        City, 
                        State, 
                        Zip, 
                        MobilePhoneAreaCode, 
                        MobilePhone, 
                        HomePhoneAreaCode, 
                        HomePhone) 
                        
                        VALUES 
                        (@Id, 
                        @FirstName, 
                        @LastName, 
                        @Ssn, 
                        @DateOfBirth, 
                        @Address, 
                        @City, 
                        @State, 
                        @Zip, 
                        @MobilePhoneAreaCode, 
                        @MobilePhone, 
                        @HomePhoneAreaCode, 
                        @HomePhone)";
        }
    }
}
