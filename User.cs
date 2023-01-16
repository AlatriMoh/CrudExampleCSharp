using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class User
    {
        public User(string ConnectionString) { this.ConnectionString = ConnectionString; }

        public Int64 Id { set; get; }
        public String No { set; get; }
        public String Name { set; get; }
        public String Password { set; get; }
        public String Note { set; get; }
        public Int64 CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public Int64 LastUpdatedBy { set; get; }
        public DateTime LastUpdatedAt { set; get; }
        public String ConnectionString { set; get; }

        public void Add()
        {
            var queryScript = $@"
INSERT INTO TblUsers (Id_, No, Name, Password, Note, CreatedBy, CreatedAt, LastUpdatedBy, LastUpdatedAt) 
VALUES (@Id_, @No, @Name, @Password, @Note, @CreatedBy, @CreatedAt, @LastUpdatedBy, @LastUpdatedAt);
        ";
            try
            {
                using (var sqlConnection = new SqlConnection(this.ConnectionString))
                using (var sqlCommand = new SqlCommand(queryScript, sqlConnection))
                {

                    sqlCommand.Parameters.Add("@Id_", SqlDbType.BigInt).Value = this.Id;
                    sqlCommand.Parameters.Add("@No", SqlDbType.NVarChar).Value = this.No;
                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = this.Name;
                    sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = this.Password;
                    sqlCommand.Parameters.Add("@Note", SqlDbType.NVarChar).Value = this.Note;
                    sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = this.CreatedBy;
                    sqlCommand.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = this.CreatedAt;
                    sqlCommand.Parameters.Add("@LastUpdatedBy", SqlDbType.BigInt).Value = this.LastUpdatedBy;
                    sqlCommand.Parameters.Add("@LastUpdatedAt", SqlDbType.DateTime).Value = this.LastUpdatedAt;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Modify()
        {
            var queryScript = $@"
UPDATE TblUsers SET 
	No= @No, 
	Name= @Name, 
	Password= @Password, 
	Note= @Note, 
	CreatedBy= @CreatedBy, 
	CreatedAt= @CreatedAt, 
	LastUpdatedBy= @LastUpdatedBy, 
	LastUpdatedAt= @LastUpdatedAt
WHERE Id_=@Id_;
        ";
            try
            {
                using (var sqlConnection = new SqlConnection(this.ConnectionString))
                using (var sqlCommand = new SqlCommand(queryScript, sqlConnection))
                {

                    sqlCommand.Parameters.Add("@Id_", SqlDbType.BigInt).Value = this.Id;
                    sqlCommand.Parameters.Add("@No", SqlDbType.NVarChar).Value = this.No;
                    sqlCommand.Parameters.Add("@Name", SqlDbType.NVarChar).Value = this.Name;
                    sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar).Value = this.Password;
                    sqlCommand.Parameters.Add("@Note", SqlDbType.NVarChar).Value = this.Note;
                    sqlCommand.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = this.CreatedBy;
                    sqlCommand.Parameters.Add("@CreatedAt", SqlDbType.DateTime).Value = this.CreatedAt;
                    sqlCommand.Parameters.Add("@LastUpdatedBy", SqlDbType.BigInt).Value = this.LastUpdatedBy;
                    sqlCommand.Parameters.Add("@LastUpdatedAt", SqlDbType.DateTime).Value = this.LastUpdatedAt;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        


        public void Remove()
        {
            var queryScript = $@"
DELETE FROM TblUsers 
WHERE Id_=@Id_;
        ";
            try
            {
                using (var sqlConnection = new SqlConnection(this.ConnectionString))
                using (var sqlCommand = new SqlCommand(queryScript, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@Id_", SqlDbType.BigInt).Value = this.Id;
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
}
