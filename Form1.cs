using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using SpreadsheetLight;

/****
----Fredy Garate Marín
----26/08/2021
----Programa para agilizar las consultas de los tramites, leé un archivo de excel con No. de trámites y hace un filtro, 

*****/

namespace Consultor
{
    public partial class Form1 : Form
    {
        public String strConexion = "server=192.168.3.12; database=SERVERBOX; uid=geoBox; pwd=geoBox123*;";
        private SqlConnection con = null;
        private SqlCommand OrdenSql;
        private SqlDataReader Leer;
        List<string> lstTempT = new List<string>();
        List<string> lstTempF = new List<string>();
        List<string> lstTempS = new List<string>();
        List<string> lstTempO = new List<string>();
        List<string> lstTempTa = new List<string>();
        List<string> lstTempD = new List<string>();
       
        public int cont = 0, pos = 0, Position = 0;
        public bool band;
        DataTable dt = new DataTable(); //DataTable
      

        public Form1()
        {
            InitializeComponent();
            dgDatosFiltrados.AutoGenerateColumns = true;

            dt.Columns.Add("No.Tramite");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Status");
            dt.Columns.Add("Tarea");
            dt.Columns.Add("Delegacion");
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaArchivo = openFileDialog1.FileName;
                    txtNameFile.Text = rutaArchivo;
                    if (lsvConsultados.Items.Count > 0)
                    {
                        dt.Clear();
                        lsvConsultados.Items.Clear();
                        btnFiltrar.Enabled = false;
                        pbImagen.Visible = false;
                        txtFiltrar.ReadOnly = true;
                        btnImprimir.Enabled = false;
                        cbStatus.Enabled = false;
                        dtpFechaI.Enabled = false;
                        dtpFechaF.Enabled = false;
                        pbGood.Visible = false;
                    }
                    else
                    {
                       
                        CargarDatos(rutaArchivo);
                        btnConsultar.Enabled = true;
                        txtFiltrar.ReadOnly = true;
                        pbImagen.Visible = false;
                    }
                   
                    
                    
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        public void CargarDatos(string rutaArchivo)
        {
            lsvDatosCargados.Items.Clear();
            try
            {
          
                    SLDocument ArchivoExcel = new SLDocument(rutaArchivo);
                    int iRow = 1;
                    if (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                        {

                            //Capturando los valores
                            string NumTramite = ArchivoExcel.GetCellValueAsString(iRow, 1);
                            ListViewItem fila = new ListViewItem(NumTramite);
                            lsvDatosCargados.Items.Add(fila);
                            iRow++;

                        }
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
                labelProgreso.Visible = true;
                progressBar1.Visible = true;
                labelProgreso.Text = "0%";
                progressBar1.Value = 0;
                lblProcesando.Visible = true;
                dt.Clear();
                btnFiltrar.Enabled = false;
                txtFiltrar.ReadOnly = true;
                txtFiltrar.Cursor = Cursors.No;
                pbImagen.Visible = false;
                pbGood.Visible = false;
                cbStatus.Enabled = false;
                dtpFechaI.Enabled = false;
                dtpFechaF.Enabled = false;

            }
            else
            {
            
                MessageBox.Show("Espere a que termine el proceso...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           
            dt.Clear();
            BuscarTramiteEnlsvConsultados();
            btnImprimir.Enabled = true;
        }
        public void BuscarTramiteEnlsvConsultados()
        {
            try
            {
                for (int i = 0; i < lsvDatosCargados.Items.Count; i++)
                {

                    for (int j = 0; j < lsvConsultados.Items.Count; j++)
                    {
                        if (lsvDatosCargados.Items[i].SubItems[0].Text == lsvConsultados.Items[j].SubItems[0].Text)
                        {

                            lstTempT.Add(lsvConsultados.Items[j].SubItems[0].Text);
                            lstTempF.Add(lsvConsultados.Items[j].SubItems[1].Text);
                            lstTempS.Add(lsvConsultados.Items[j].SubItems[2].Text);
                            lstTempO.Add(lsvConsultados.Items[j].SubItems[3].Text);
                            lstTempTa.Add(lsvConsultados.Items[j].SubItems[4].Text);
                            lstTempD.Add(lsvConsultados.Items[j].SubItems[5].Text);


                        }
                    }

                    FiltroLogicoEficiente(lstTempT, lstTempF, lstTempS, lstTempO, lstTempTa, lstTempD);
                    lstTempT.Clear();
                    lstTempF.Clear();
                    lstTempS.Clear();
                    lstTempO.Clear();
                    lstTempTa.Clear();
                    lstTempD.Clear();

                }
                pbImagen.Visible = true;
                txtFiltrar.ReadOnly = false;
                cbStatus.Enabled = true;
                dtpFechaI.Enabled = true;
                dtpFechaF.Enabled = true;
                txtFiltrar.Cursor = Cursors.IBeam;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
      

        
        public void FiltroLogicoEficiente(List<string> lstTempT, List<string> lstTempF, List<string> lstTempS, List<string> lstTempO, List<string> lstTempTa, List<string> lstTempD)
        {
            
            int i = 0;

           


            while (i < lstTempS.Count -1)
            {
                if (lstTempS.ElementAt(i) != lstTempS.ElementAt((i + 1))) //Encuentra par diferentes
                {
                    band = true;
                    pos = i;
                }
                i++;
            }
            if (band)
            {
                if (lstTempS.ElementAt(pos) != "CANCELADO" || lstTempS.ElementAt(pos) != "PAUSADO" || lstTempS.ElementAt(pos) != "INICIADO" || lstTempS.ElementAt(pos) != "PROCESO" || lstTempS.ElementAt(pos) != "PENDIENTE")
                {
                    
                   

                    dt.Rows.Add(new object[] { lstTempT.ElementAt(pos + 1), lstTempF.ElementAt(pos + 1), lstTempS.ElementAt(pos + 1), lstTempTa.ElementAt(pos + 1), lstTempD.ElementAt(pos + 1) });
                    dgDatosFiltrados.DataSource = dt;
                            
                }
                else
                {
                 
                    dt.Rows.Add(new object[] { lstTempT.ElementAt(pos), lstTempF.ElementAt(pos), lstTempS.ElementAt(pos), lstTempTa.ElementAt(pos), lstTempD.ElementAt(pos) });
                    dgDatosFiltrados.DataSource = dt;
                }
              
                pos = 0;
                band = false;
            }
            else
            {
               
                dt.Rows.Add(new object[] { lstTempT.ElementAt(lstTempD.Count - 1), lstTempF.ElementAt(lstTempD.Count - 1), lstTempS.ElementAt(lstTempD.Count - 1), lstTempTa.ElementAt(lstTempD.Count - 1), lstTempD.ElementAt(lstTempD.Count - 1) });
                dgDatosFiltrados.DataSource = dt;
            }

        }

       



        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CrearExcel();
        }

      

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = $"no.tramite LIKE '{txtFiltrar.Text}%' OR status LIKE '{txtFiltrar.Text}%' OR tarea LIKE '{txtFiltrar.Text}%' ";
            cbStatus.SelectedIndex = 0;
        }

        

        public void CrearExcel()
        {
            string rutaNameFile = txtNameFile.Text;
            string rutaC = rutaNameFile.Remove(rutaNameFile.Length - 10);
            
            string rutaArchivoCompleta = @rutaC+" DatosFiltrados.xlsx";
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                sl.SetCellValue(1, 1, "No.Trámite");
                sl.SetCellValue(1, 2, "Fecha");
                sl.SetCellValue(1, 3, "status");
               // sl.SetCellValue(1, 4, "Orden");
                sl.SetCellValue(1, 4, "Tarea");
                sl.SetCellValue(1, 5, "Delegación");
                
                for (int i = 0; i < dgDatosFiltrados.RowCount - 1; i++)
                {
                    


                    sl.SetCellValue(i + 2, 1, dgDatosFiltrados.Rows[i].Cells[0].Value.ToString());
                    sl.SetCellValue(i + 2, 2, dgDatosFiltrados.Rows[i].Cells[1].Value.ToString());
                    sl.SetCellValue(i + 2, 3, dgDatosFiltrados.Rows[i].Cells[2].Value.ToString());
                    // sl.SetCellValue(i + 2, 4, lsvFiltrados.Items[i].SubItems[3].Text);
                    sl.SetCellValue(i + 2, 4, dgDatosFiltrados.Rows[i].Cells[3].Value.ToString());
                    sl.SetCellValue(i + 2, 5, dgDatosFiltrados.Rows[i].Cells[4].Value.ToString());



                }
               
                sl.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Archivo guardado correctamente en el escritorio!", "Información de archivo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡ALGO SALIO MAL :(! INFORMACIÓN: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /************Propiedades backgroundworker*****************/
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string tramite, fechaC, status, orden, tarea, delegacion, datos = "";
            DateTime fecha;
            int porciento = 0, totalEmpleadosProcesar = 0;

            //for (int indice = 0; indice < 92500; indice++) //Ciclo que representará los empleados seleccionados
            //{
            //    totalEmpleadosProcesar = 92500;  //Total de Empleados que seleccionó el usuario

            //    progreso++; //Aumentando el progreso 
            //    porciento = Convert.ToInt16((((double)progreso / (double)totalEmpleadosProcesar) * 100.00)); //Calculo del porcentaje
            //    //Thread.Sleep(10);
            //    backgroundWorker1.ReportProgress(porciento);

            //}
           
                for (int i = 0; i < lsvDatosCargados.Items.Count; i++)
                {
                        this.Invoke((MethodInvoker)delegate ()
                            {
                            datos += "'" + lsvDatosCargados.Items[i].SubItems[0].Text + "',";
                             });
               
            }


           
                try
                {
                    con = new SqlConnection(strConexion);
                    using (con)
                    {
                        string ConsultarTramite = "select DISTINCT ST.fk_nroTramite, CONVERT(DATE, SIS_Tramite.fechaInicial),  E.estatus, ST.ordenJerarquico, TT.nombre, (SELECT nombreDelegacion FROM CAT_Municipio cmun  INNER JOIN  CAT_DelegacionesMunicipales   on[idDelegacionM] = cmun.[fkIdDelegacionM] WHERE idMunicipio = SUBSTRING(ST.fk_nroTramite, 13, 15)) " +
                            "from SIS_SeguimientoTramite ST inner join CAT_Estatus E on E.idEstatus = ST.fk_estatus inner join CAT_TareasPorTramite TT on ST.fk_tareasPorTramite = TT.idTareasPorProceso inner join SIS_Tramite on st.fk_nroTramite = tramite " +
                            "where e.estatus <> 'NO INICIADO'  and fk_nroTramite in (" + datos.Remove(datos.Length - 1) + ") order by fk_nroTramite, ordenJerarquico";

                        OrdenSql = new SqlCommand(ConsultarTramite, con);
                        con.Open();
                        DataTable dtQ = new DataTable();
                        dtQ.Load(OrdenSql.ExecuteReader()); //Cargo mis datos en un DataTable
                        totalEmpleadosProcesar = dtQ.Rows.Count; //Obtengo el total de elementos que se van a procesar
                        Leer = OrdenSql.ExecuteReader();
                        while (Leer.Read())
                        {

                            cont++;
                            tramite = Leer[0].ToString();
                            fecha = DateTime.Parse(Leer[1].ToString());
                            fechaC = fecha.ToString("dd/MM/yyyy");
                            status = Leer[2].ToString();
                            orden = Leer[3].ToString();
                            tarea = Leer[4].ToString();
                            delegacion = Leer[5].ToString();
                            ListViewItem fila = new ListViewItem(tramite);
                            fila.SubItems.Add(fechaC);
                            fila.SubItems.Add(status);
                            fila.SubItems.Add(orden);
                            fila.SubItems.Add(tarea);
                            fila.SubItems.Add(delegacion);
                            fila.SubItems.Add(cont.ToString());
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            lsvConsultados.Items.Add(fila);
                        });
                            porciento = Convert.ToInt16((((double)cont / (double)totalEmpleadosProcesar) * 100.00)); //Calculo del porcentaje
                            backgroundWorker1.ReportProgress(porciento);

                    }
                        cont = 0;
                        con.Close();
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        btnFiltrar.Enabled = true;
                        txtFiltrar.ReadOnly = true;
                        pbImagen.Visible = false;
                        btnImprimir.Enabled = false;
                    });
                    dt.Clear();
                        dtQ.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            




        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex != -1)
            {
                if(cbStatus.SelectedItem.ToString() != "-Seleccione-")
                {
                    dt.DefaultView.RowFilter = $"status LIKE '{cbStatus.SelectedItem.ToString()}%'";
                }
                else
                {
                    dt.DefaultView.RowFilter = $"status LIKE '{""}%'";
                }
                
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarFechas_Click(object sender, EventArgs e)
        {
             DateTime FechaI = dtpFechaI.Value;
             DateTime FechaF = dtpFechaF.Value;
         
            string fi = FechaI.ToShortDateString(),ff=FechaF.ToShortDateString();
           
              if (FechaI <= FechaF)
              {
                 dt.DefaultView.RowFilter = string.Format("fecha >= #{0}# and fecha <= #{1}# ", Convert.ToDateTime(fi).ToString("MM/dd/yyyy"), Convert.ToDateTime(ff).ToString("MM/dd/yyyy"));
                
            }
        }




        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgreso.Text = Convert.ToString(e.ProgressPercentage) + "%";
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled == true)
            {
                MessageBox.Show("Se cancela");
            }else if(e.Error!= null)
            {
                MessageBox.Show("Ocurrio un error: " + e.Error.Message);
            }
            else
            {
             //   MessageBox.Show("Ha finalizado correctamente el proceso","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                labelProgreso.Visible = false;
                progressBar1.Visible = false;
                pbGood.Visible = true;
                lblProcesando.Visible = false;
                
            }
           
        }
        /****************************/


    }
}
