using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingFile_Sanchez
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            List<string> programs = new List<string>
            {
                "Bachelor of Science in Computer Science",
                "Bachelor of Science in Information Technology",
                "Bachelor of Science in Information Systems",
                "Bachelor of Science in Computer Engineering"
            };

            cbProgram.DataSource = programs;

            List<string> gender = new List<string>
            {
                "Female",
                "Male",
                "Others"
            };

            cbGender.DataSource = gender;
        }

        private void btnRegistered_Click(object sender, EventArgs e)
        {
            string docName = tbStudNo.Text + "-" + tbLastName.Text + ".txt";
            string docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string[] userInfo =
            {
                "Student No.: " + tbStudNo.Text,
                "Full Name: " + tbLastName.Text + ", " + tbFirstName.Text + " " + tbMI.Text,
                "Program: " + cbProgram.Text,
                "Gender: " + cbGender.Text,
                "Age: " + tbAge.Text,
                "Birthday: " + dtpBirthday.Text,
                "Contact No.: " + tbContactNo.Text
 };
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docpath, docName)))
            {
                foreach (string info in userInfo)
                {
                    outputFile.WriteLine(info);
                }
            }
            Close();

        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            FrmRegistration records = new FrmRegistration();
            records.ShowDialog();
            Close();
        }
    }
}
