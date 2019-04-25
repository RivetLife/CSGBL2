using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace DataBase
{
    /// <summary>
    /// Сводное описание для Lesson8
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class Lesson8 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public void Init(ref SqlConnection connection, ref SqlDataAdapter adapter, ref DataTable dt)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Lesson7;Integrated Security=True;Pooling=False";
            connection = new SqlConnection(connectionString);

            adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT Id, name, department_id FROM Employee", connection);
            adapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO Employee (name, department_id) VALUES (@name, @department_id); SET @ID = @@IDENTITY;", connection);
            command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            command.Parameters.Add("@department_id", SqlDbType.Int, 100, "department_id");
            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = command;

            command = new SqlCommand(@"UPDATE Employee SET name = @name, department_id = @department_id WHERE ID = @ID", connection);
            command.Parameters.Add("@name", SqlDbType.NVarChar, -1, "name");
            command.Parameters.Add("@department_id", SqlDbType.Int, 100, "department_id");
            param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = command;

            dt = new DataTable();
            adapter.Fill(dt);
        }

        [WebMethod]
        public void ChangeDepartment(int selectedIndex, DataRowView selectedItem, ref SqlDataAdapter adapter, ref DataTable dt)
        {
            DataRowView newRow = selectedItem;
            newRow.BeginEdit();
            newRow["department_id"] = selectedIndex + 1;
            newRow.EndEdit();
            adapter.Update(dt);
        }

        [WebMethod]
        public void AddEmployee (int selectedIndex, string txt, ref SqlDataAdapter adapter, ref DataTable dt)
        {
            DataRow newRow = dt.NewRow();
            newRow["name"] = txt;
            newRow["department_id"] = selectedIndex + 1;
            dt.Rows.Add(newRow);
            adapter.Update(dt);
        }

    }
}
