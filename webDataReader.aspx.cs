using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// USING the FIreSharp (FireBase) with NuGet
using System.Data.OleDb;

namespace OLEDB
{
    public partial class webDataReader : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader rdStudents;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("~/App_Data/College.mdb"));
                myCon.Open();

                myCmd = new OleDbCommand("SELECT [Number], [RefCourse] FROM Courses ORDER BY [Number]", myCon);
                rdStudents = myCmd.ExecuteReader();

                lstCourse.DataTextField = "Number";
                lstCourse.DataValueField = "RefCourse";
                lstCourse.DataSource = rdStudents;
                lstCourse.DataBind();

                /*
                // To Test the connection with hardcode 
                // Optional
                string sql = "SELECT * FROM Courses WHERE Teacher =@teach and Duration <@dur ";
                OleDbCommand myCmdTest = new OleDbCommand(sql, myCon);
                OleDbParameter myPart = new OleDbParameter("teach", "Houria Houmel");
                myPart.DbType = System.Data.DbType.String;
                myCmdTest.Parameters.Add(myPart);

                myCmdTest.Parameters.AddWithValue("dur", 50);
                OleDbDataReader rdTest = myCmdTest.ExecuteReader();

                gridTest.DataSource = rdTest;
                gridTest.DataBind();
                */

                
                myCmd = new OleDbCommand("SELECT * FROM Courses", myCon);
                rdStudents = myCmd.ExecuteReader();
                gridTest.DataSource = rdStudents;
                gridTest.DataBind();
                
            }

        }

        protected void lstCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("SELECT * FROM Courses WHERE RefCourse =@ref", myCon);
            myCmd.Parameters.AddWithValue("ref", lstCourse.SelectedItem.Value);

            rdStudents = myCmd.ExecuteReader();
            if (rdStudents.Read())
            {
                txtNumber.Text = rdStudents["Number"].ToString();
                txtTitle.Text = rdStudents["Title"].ToString();
                txtDuration.Text = rdStudents["Duration"].ToString();
                txtTeacher.Text = rdStudents["Teacher"].ToString();
                txtDescription.Text = rdStudents["Description"].ToString();

            }
            rdStudents.Close();

            myCmd.CommandText = "SELECT StudentName as [Names], BirthDate as [Birth Dates], " +
                "Telephone, Average, Email FROM Students WHERE ReferCourse =@ref";

            rdStudents = myCmd.ExecuteReader();
            gridResults.DataSource = rdStudents;
            gridResults.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int refC = Convert.ToInt32(lstCourse.SelectedItem.Value);
            string sql = "UPDATE Courses SET Duration=@dur, Teacher=@tea, Description=@desc WHERE RefCourse=@courseId";
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            myCmd.Parameters.AddWithValue("dur", Convert.ToInt32(txtDuration.Text));
            myCmd.Parameters.AddWithValue("tea", txtTeacher.Text);
            myCmd.Parameters.AddWithValue("desc", txtDescription.Text);
            myCmd.Parameters.AddWithValue("courseId", refC);

            // Excute the SQL Query without returns the data
            // int result =
            myCmd.ExecuteNonQuery();

            Response.Write("<script>alert(\"Update\");</script>");

        }
    }
}