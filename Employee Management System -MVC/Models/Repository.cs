using System;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using ems.Models;
namespace ems.Models
{
    public class Repository
    {
        public List<Employee> DisplayDetails()
        {
            List<Employee> AllEmployee = new List<Employee>();
            using(SqlConnection connection = new SqlConnection(getConnection()))
            {
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="GetAllEmployee";
                SqlDataAdapter sqlDataAdapter =new SqlDataAdapter(command);
                DataTable dataTable= new DataTable();
                connection.Open();
                sqlDataAdapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    Employee employee =new Employee();
                    employee.EmployeeID=Convert.ToInt32(row["EmployeeID"]);
                    employee.EmployeeName=Convert.ToString(row["EmployeeName"]);
                    employee.Age=Convert.ToInt32(row["Age"]);
                    employee.Department=Convert.ToString(row["Department"]);
                    employee.Salary=Convert.ToInt32(row["Salary"]);
                    employee.Email=Convert.ToString(row["Email"]);
                    employee.Password=Convert.ToString(row["Password"]);
                    employee.MobileNumber=Convert.ToString(row["MobileNumber"]);
                    employee.Nationality=Convert.ToString(row["Nationality"]);
                    employee.State=Convert.ToString(row["State"]);
                    employee.DateOfBirth=Convert.ToString(row["DateOfBirth"]);
                    employee.Gender=Convert.ToString(row["Gender"]);
                    employee.AccountNo=Convert.ToString(row["AccountNo"]);
                    AllEmployee.Add(employee);
                }
            }
            return AllEmployee;
        } 
        public  void CreateEmployee(Employee employee)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command =connection.CreateCommand();
                    command.CommandType=CommandType.StoredProcedure;
                    command.CommandText="InsertEmployee";
                    command.Parameters.AddWithValue("@EmployeeID",employee.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName",employee.EmployeeName);
                    command.Parameters.AddWithValue("@Age",employee.Age);
                    command.Parameters.AddWithValue("@Salary",employee.Salary);
                    command.Parameters.AddWithValue("@Department",employee.Department);
                    command.Parameters.AddWithValue("@Email",employee.Email);
                    command.Parameters.AddWithValue("@Password",employee.Password);
                    command.Parameters.AddWithValue("@MobileNumber", employee.MobileNumber);
                    command.Parameters.AddWithValue("@ProfilePIC","../images/"+employee.ProfilePIC);
                    command.Parameters.AddWithValue("@Nationality",employee.Nationality);
                    command.Parameters.AddWithValue("@State",employee.State);
                    command.Parameters.AddWithValue("@DateOfBirth",employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender",employee.Gender);
                    command.Parameters.AddWithValue("@AccountNo",employee.AccountNo);
                    connection.Open();
                    command.ExecuteNonQuery();     
                }
            }
            catch(SqlException exception){
                Console.WriteLine(exception.Message);}
            catch(IOException exception){
                Console.WriteLine(exception.Message);}
            catch(Exception exception){
                Console.WriteLine(exception.Message);}
        }
        public  void UpdateEmployee(Employee employee)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command =connection.CreateCommand();
                    command.CommandType=CommandType.StoredProcedure;
                    command.CommandText="UpdateEmployee";
                    command.Parameters.AddWithValue("@EmployeeID",employee.EmployeeID);
                    command.Parameters.AddWithValue("@EmployeeName",employee.EmployeeName);
                    command.Parameters.AddWithValue("@Age",employee.Age);
                    command.Parameters.AddWithValue("@Salary",employee.Salary);
                    command.Parameters.AddWithValue("@Department",employee.Department);
                    command.Parameters.AddWithValue("@Email",employee.Email);
                    command.Parameters.AddWithValue("@Password",employee.Password);
                    command.Parameters.AddWithValue("@MobileNumber",employee.MobileNumber);
                    command.Parameters.AddWithValue("@ProfilePIC","../images/"+employee.ProfilePIC);
                    command.Parameters.AddWithValue("@Nationality",employee.Nationality);
                    command.Parameters.AddWithValue("@State",employee.State);
                    command.Parameters.AddWithValue("@DateOfBirth",employee.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender",employee.Gender);
                    command.Parameters.AddWithValue("@AccountNo",employee.AccountNo);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
           
            }
            catch(SqlException exception){
                Console.WriteLine(exception.Message);}
            catch(IOException exception){
                Console.WriteLine(exception.Message);}
            catch(Exception exception){
                Console.WriteLine(exception.Message);}
        }
        public  void DeleteEmployee(int EmployeeID)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command =connection.CreateCommand();
                    command.CommandType=CommandType.StoredProcedure;
                    command.CommandText="DeleteEmployee";
                    command.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException exception){
                Console.WriteLine(exception.Message);}
            catch(IOException exception){
                Console.WriteLine(exception.Message);}
            catch(Exception exception){
                Console.WriteLine(exception.Message);}
        }
        public  Employee SearchEmployee(int EmployeeID)
        {
            Employee employee =new Employee();
            try
            {
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command =connection.CreateCommand();
                    command.CommandType=CommandType.StoredProcedure;
                    command.CommandText="SearchEmployee";
                    command.Parameters.AddWithValue("@EmployeeID",EmployeeID);
                    SqlDataAdapter sqlDataAdapter =new SqlDataAdapter(command);
                    DataTable dataTable= new DataTable();
                    connection.Open();
                    sqlDataAdapter.Fill(dataTable);
                    foreach(DataRow row in dataTable.Rows)
                    {
                        employee.EmployeeID=Convert.ToInt32(row["EmployeeID"]);
                        employee.EmployeeName=Convert.ToString(row["EmployeeName"]);
                        employee.Age=Convert.ToInt32(row["Age"]);
                        employee.Department=Convert.ToString(row["Department"]);
                        employee.Salary=Convert.ToInt32(row["Salary"]);
                        employee.Email=Convert.ToString(row["Email"]);
                        employee.Password=Convert.ToString(row["Password"]);
                        employee.MobileNumber=Convert.ToString(row["MobileNumber"]);
                        employee.ProfilePIC="../images/"+Convert.ToString(row["ProfilePIC"]);
                        employee.Nationality=Convert.ToString(row["Nationality"]);
                        employee.State=Convert.ToString(row["State"]);
                        employee.DateOfBirth=Convert.ToString(row["DateOfBirth"]);
                        employee.Gender=Convert.ToString(row["Gender"]);
                        employee.AccountNo=Convert.ToString(row["AccountNo"]);
                    }
                }
            }
            catch(SqlException exception){
                Console.WriteLine(exception.Message);}
            catch(IOException exception){
                Console.WriteLine(exception.Message);}
            catch(Exception exception){
                Console.WriteLine(exception.Message);}
            return employee;
        }
        public bool IsValidAdmin(Employee employee)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isvalidadmin";
                command.Parameters.AddWithValue("@AdminID",employee.UserId);
                command.Parameters.AddWithValue("@Password",employee.Password);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 1){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;
                         
        }

         public  bool IsValidEmployee(Employee employee)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidEmployee";
                command.Parameters.AddWithValue("@EmployeeID",employee.UserId);
                command.Parameters.AddWithValue("@Password",employee.Password);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 1){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;       
        }
        public  bool IsValidId(int EmployeeID)
        {      
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidId";
                command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 1){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;         
        }
        public  bool IsValidUser(int EmployeeID)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidUser";
                command.Parameters.AddWithValue("@EmployeeID",EmployeeID);

                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 0){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;             
        }

        public  bool IsValidAccount(string AccountNo)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidAccount";
                command.Parameters.AddWithValue("@AccountNo",AccountNo);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 0){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;         
        }
        public  bool IsValidNumber(string MobileNumber)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidNumber";
                command.Parameters.AddWithValue("@MobileNumber",MobileNumber);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 0){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;             
        }
        public  bool IsValidMail(string Email)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidMail";
                command.Parameters.AddWithValue("@Email",Email);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 0){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;                    
        }

        public  string ChangePassword(Employee employee)
        {           
            SqlConnection connection = new SqlConnection(getConnection());
            SqlCommand command=new SqlCommand($"Select count(Email) from EmployeeData where Email='{employee.Email}'",connection);
            connection.Open();
                if(Convert.ToInt32(command.ExecuteScalar())==1)
                {
                    if(String.Equals(employee.Password,employee.ConfirmPassword))
                    {                        
                        if(Regex.IsMatch(employee.Password,"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$"))
                        {
                            SqlCommand command1=new SqlCommand($"Update EmployeeData set Password = '{employee.Password}' where Email= '{employee.Email}';",connection);
                            command1.ExecuteNonQuery();
                            connection.Close();
                            return "Success";
                        }
                        else
                        {
                            connection.Close();
                            return "Invalid";                            
                        }
                    }
                    else
                    {
                        connection.Close();
                        return "notEquals";                        
                    }
                }
                else
                {
                    connection.Close();
                    return "notExist";          
                }           
        }
        public  bool IsValidTask(string task)
        {
                int result =0;
                SqlConnection connection = new SqlConnection(getConnection());
                SqlCommand command =connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText="isValidTask";
                command.Parameters.AddWithValue("@task",task);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Result"];
                }
                if(result == 0){
                    connection.Close();
                    return true;
                }                
                connection.Close();
                return false;          
        }
        public  void DeleteItem(string task)
        {
            
             try{
                using(SqlConnection connection=new SqlConnection(getConnection()))
                {
                    SqlCommand command =connection.CreateCommand();
                    command.CommandType=CommandType.StoredProcedure;
                    command.CommandText="deleteItem";
                    command.Parameters.AddWithValue("@task",task);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
             }
             catch(SqlException exception){
                 Console.WriteLine(exception.Message);}
             catch(IOException exception){
                 Console.WriteLine(exception.Message);}
             catch(Exception exception){
                 Console.WriteLine(exception.Message);}
        }
           
        public static string? getConnection()
        {
        var build = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json",optional:true,reloadOnChange:true);
        IConfiguration configuration = build.Build();
        string? connectionString = Convert.ToString(configuration.GetConnectionString("DB1"));
        return connectionString;
        }
    }
}