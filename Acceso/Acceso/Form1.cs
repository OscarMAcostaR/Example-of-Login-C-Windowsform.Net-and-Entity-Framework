using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acceso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string spass = Encrypt.GetSHA256(txtPassword.Text.Trim());

            using (Models.WindowsFormsEntities db = new Models.WindowsFormsEntities())
            {
                var lst = from d in db.user
                          where d.email == txtUser.Text
                          && d.password == spass
                          select d;
                if (lst.Count() >0)
                {
                    //// MessageBox.Show("Usuario existe");
                    this.Hide(); 
                    FrmMain principal = new FrmMain();
                    principal.FormClosed += (S, args) => this.Close(); 
                    principal.Show();
                    
                }
                else
                {
                    MessageBox.Show("Usuario no existe");
                }
            }
        }
    }
}
