using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace OLEDB
{
    public partial class webCollege : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        OleDbCommand myCmd;
        OleDbDataReader rdCourses, rdPrograms, rdSchools, rdStudents;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + Server.MapPath("~/App_Data/College2.mdb"));
                myCon.Open();

                panPrograms.Visible = false;
                panCourse.Visible = false;

                myCmd = new OleDbCommand("SELECT [Title], [refSchool] FROM Schools ORDER BY [Title]", myCon);
                rdSchools = myCmd.ExecuteReader();

                radlistSchool.DataTextField = "Title";
                radlistSchool.DataValueField = "refSchool";
                radlistSchool.DataSource = rdSchools;
                radlistSchool.DataBind();
                rdSchools.Close();

            } else
            {
                panPrograms.Visible = false;
                panCourse.Visible = false;
                gridStudents.Visible = false;
            }
        }

        protected void radlistSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("SELECT [Title], [refProgram] FROM Programs WHERE referSchool =@schoolId ORDER BY [Title]", myCon);
            myCmd.Parameters.AddWithValue("schoolId", radlistSchool.SelectedItem.Value);
            rdPrograms = myCmd.ExecuteReader();

            radlstPrograms.DataTextField = "Title";
            radlstPrograms.DataValueField = "refProgram";
            radlstPrograms.DataSource = rdPrograms;
            radlstPrograms.DataBind();

            rdPrograms.Close();
            panPrograms.Visible = true;

        }

        protected void radlstPrograms_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCmd = new OleDbCommand("SELECT [Number], [RefCourse] FROM Courses WHERE referProgram =@programId ORDER BY [Number]", myCon);
            myCmd.Parameters.AddWithValue("programId", radlstPrograms.SelectedItem.Value);
            rdCourses = myCmd.ExecuteReader();

            chklstCourses.DataTextField = "Number";
            chklstCourses.DataValueField = "RefCourse";
            chklstCourses.DataSource = rdCourses;
            chklstCourses.DataBind();

            rdCourses.Close();
            panPrograms.Visible = true;
            panCourse.Visible = true;

        }

        protected void chklstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> lstStudent = new List<string>();



            foreach (ListItem item in chklstCourses.Items)
            {
                if (item.Selected)
                {
                    myCmd = new OleDbCommand("SELECT StudentName as [Name], BirthDate as [Birth Date], Telephone, Average, Email FROM Students WHERE ReferCourse =@courseId", myCon);
                    myCmd.Parameters.AddWithValue("courseId", item.Value);
                    rdStudents = myCmd.ExecuteReader();
                    
                    if (rdStudents.HasRows)
                    {
                        while (rdStudents.Read())
                        {
                            lstStudent.Add(rdStudents["Name"].ToString() + "  " + rdStudents["Birth Date"].ToString() + "  " + rdStudents["Telephone"].ToString() +
                                "  " + rdStudents["Average"].ToString() + "  " + rdStudents["Email"].ToString());
                        }
                    }  
                }
            }

            rdStudents.Close();
            lstStudent.Sort();
            gridStudents.DataSource = lstStudent;
            gridStudents.DataBind();

            panPrograms.Visible = true;
            panCourse.Visible = true;
            gridStudents.Visible = true;

        }

        protected void gridStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}