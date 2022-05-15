using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public class clsGrafica
    {
        const int R = 23; 
        public static void setDgvChat(DataGridView dgv)
        {
            //funzione che imposta la grafica della dgv relativa alla chat

            dgv.ColumnCount = 1; //numero colonne
            dgv.ColumnHeadersVisible = false; //intestazione colonne 
            dgv.RowHeadersVisible = false; //intestazione righe 
            dgv.RowCount = 25; //numero righe
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Rows[R].Cells[0].Value = "zz";
            dgv.FirstDisplayedScrollingRowIndex = dgv.Rows.Count - 1;
            dgv.Columns[0].Width = dgv.Width;

            /*dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            //aspetto righe dispari 
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            */
        }
        public static void setDgvUtenti(DataGridView dgv)
        {
            //funzione che imposta la grafica della dgv relativa alla lista di utenti online

            dgv.ColumnCount = 1; //numero colonne
            dgv.ColumnHeadersVisible = false; //intestazione colonne 
            dgv.RowHeadersVisible = false; //intestazione righe 
            dgv.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.RowsDefaultCellStyle.ForeColor = Color.Black;
            //aspetto righe dispari 
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue; 
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

        }
        public static void scriviSuDgv(string id)
        {

        }
    }
}
