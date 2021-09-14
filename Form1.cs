using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Windows.Forms;

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

            //Declaro columnas de DataTable
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

                    dt.Clear();
                    lsvConsultados.Items.Clear();


                    pbImagen.Visible = false;
                    txtFiltrar.ReadOnly = true;
                    btnImprimir.Enabled = false;
                    cbStatus.Enabled = false;
                    cbTarea.Enabled = false;
                    cbDelegacion.Enabled = false;
                    dtpFechaI.Enabled = false;
                    dtpFechaF.Enabled = false;
                    pbGood.Visible = false;
                    btnConsultar.Enabled = true;
                    CargarDatos(rutaArchivo);







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
                        if (!string.IsNullOrWhiteSpace(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                        {
                            //Capturando los valores
                            string NumTramite = ArchivoExcel.GetCellValueAsString(iRow, 1);
                            ListViewItem fila = new ListViewItem(NumTramite);
                            lsvDatosCargados.Items.Add(fila);
                        }

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
            DateTime t1 = DateTime.Parse(dtFInicial.Value.ToString());
            DateTime t2 = DateTime.Parse(dtFFinal.Value.ToString());
            int comp = DateTime.Compare(t1, t2);


            if (backgroundWorker1.IsBusy != true)
            {
                if (comp <= 0)
                {
                    backgroundWorker1.RunWorkerAsync();
                    labelProgreso.Visible = true;
                    progressBar1.Visible = true;
                    labelProgreso.Text = "0%";
                    progressBar1.Value = 0;
                    lblProcesando.Visible = true;
                    dt.Clear();
                    lsvConsultados.Items.Clear();
                    txtFiltrar.ReadOnly = true;
                    txtFiltrar.Cursor = Cursors.No;
                    pbImagen.Visible = false;
                    pbGood.Visible = false;
                    cbStatus.Enabled = false;
                    cbTarea.Enabled = false;
                    cbDelegacion.Enabled = false;
                    dtpFechaI.Enabled = false;
                    dtpFechaF.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error en el rango de fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {

                MessageBox.Show("Espere a que termine el proceso...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }



        public void BuscarTramiteEnlsvConsultados()
        {
            try
            {
                if(lsvConsultados.Items.Count > 0)
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
                        if(lstTempT.Count > 0) //Almenos hay un dato
                        {
                            FiltroLogicoEficiente(lstTempT, lstTempF, lstTempS, lstTempO, lstTempTa, lstTempD);
                            lstTempT.Clear();
                            lstTempF.Clear();
                            lstTempS.Clear();
                            lstTempO.Clear();
                            lstTempTa.Clear();
                            lstTempD.Clear();
                        }
                       

                    }
                    pbImagen.Visible = true;
                    txtFiltrar.ReadOnly = false;
                    cbStatus.Enabled = true;
                    cbTarea.Enabled = true;
                    cbDelegacion.Enabled = true;
                    dtpFechaI.Enabled = true;
                    dtpFechaF.Enabled = true;
                    btnBuscarFechas.Enabled = true;
                    btnImprimir.Enabled = true;
                    txtFiltrar.Cursor = Cursors.IBeam;
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados...", "Información de consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void LlenarComboBox()
        {
            DataTable dtTemp = new DataTable(); //DataTable Temporal para Poder agregar Un item a combobox
            DataView vista = new DataView(dt);
            //Filtrar Status
            dtTemp = vista.ToTable(true, "Status"); //Creo un vista para poder hacer un filtro y lo guardo en DataTable Temporal
            DataRow fila1 = dtTemp.NewRow();
            fila1[0] = "-Seleccione-";
            dtTemp.Rows.InsertAt(fila1, 0); //Inserto mi Item en el ComboBox
            cbStatus.DataSource = dtTemp;
            cbStatus.ValueMember = "Status";
            cbStatus.DisplayMember = "Status";
            //Filtrar Tarea
            dtTemp = vista.ToTable(true, "Tarea"); //Creo un vista para poder hacer un filtro y lo guardo en DataTable Temporal
            DataRow fila2 = dtTemp.NewRow();
            fila2[0] = "Seleccione-";
            dtTemp.Rows.InsertAt(fila2, 0); //Inserto mi Item en el ComboBox
            cbTarea.DataSource = dtTemp;
            cbTarea.ValueMember = "Tarea";
            cbTarea.DisplayMember = "Tarea";
            //Filtrar Delegación
            dtTemp = vista.ToTable(true, "Delegacion"); //Creo un vista para poder hacer un filtro y lo guardo en DataTable Temporal
            DataRow fila3 = dtTemp.NewRow();
            fila3[0] = "-Seleccione-";
            dtTemp.Rows.InsertAt(fila3, 0); //Inserto mi Item en el ComboBox
            cbDelegacion.DataSource = dtTemp;
            cbDelegacion.ValueMember = "Delegacion";
            cbDelegacion.DisplayMember = "Delegacion";


        }

        public void FiltroLogicoEficiente(List<string> lstTempT, List<string> lstTempF, List<string> lstTempS, List<string> lstTempO, List<string> lstTempTa, List<string> lstTempD)
        {

            int i = 0;

                while (i < lstTempS.Count - 1)
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
                    //Un par diferente 
                    if (lstTempS.ElementAt(pos) == "CANCELADO" || lstTempS.ElementAt(pos) == "PAUSADO" || lstTempS.ElementAt(pos) == "INICIADO" || lstTempS.ElementAt(pos) == "PROCESO" || lstTempS.ElementAt(pos) == "PENDIENTE")
                    {

                        dt.Rows.Add(new object[] { lstTempT.ElementAt(pos), lstTempF.ElementAt(pos), lstTempS.ElementAt(pos), lstTempTa.ElementAt(pos), lstTempD.ElementAt(pos) });
                        dgDatosFiltrados.DataSource = dt;

                    }
                    else
                    {

                        dt.Rows.Add(new object[] { lstTempT.ElementAt(pos + 1), lstTempF.ElementAt(pos + 1), lstTempS.ElementAt(pos + 1), lstTempTa.ElementAt(pos + 1), lstTempD.ElementAt(pos + 1) });
                        dgDatosFiltrados.DataSource = dt;
                    }

                    pos = 0;
                    band = false;
                }
                else
                {
                    //Todos son iguales y obtengo el mayor del orden
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
            dt.DefaultView.RowFilter = $"no.tramite LIKE '{txtFiltrar.Text}%'";
            cbStatus.SelectedIndex = 0;
            cbTarea.SelectedIndex = 0;
            cbDelegacion.SelectedIndex = 0;
        }



        public void CrearExcel()
        {
            string rutaNameFile = txtNameFile.Text;
            string rutaC = rutaNameFile.Remove(rutaNameFile.Length - 10);
            string rutaArchivoCompleta = @rutaC + " DatosFiltrados.xlsx";
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Archivo de Excel|*.xlsx";
           
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();
                if (sv.ShowDialog() == DialogResult.OK)
                {
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
                    sl.SaveAs(sv.FileName);
                    MessageBox.Show("¡Archivo guardado correctamente en el escritorio!", "Información de archivo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡ALGO SALIO MAL :(! INFORMACIÓN: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /************Propiedades backgroundworker*****************/
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string tramite, fechaC, status, orden, tarea, delegacion, datos = "", ConsultarTramite;
            DateTime fecha;
            int porciento = 0, totalEmpleadosProcesar = 0;
            DateTime FI = dtFInicial.Value;
            DateTime FF = dtFFinal.Value;
            //string fi = "'" + FI.ToShortDateString() + "'", ff = "'" + FF.ToShortDateString() + "'";

            //string fi = "'20210204'", ff = "'20210408'";
            string fi = "'"+ dtFInicial.Value .ToString("yyyyMMdd")+ "'", ff = "'"+ dtFFinal.Value.ToString("yyyyMMdd")+ "'";
            for (int i = 0; i < lsvDatosCargados.Items.Count; i++)
            {
                this.Invoke((MethodInvoker)delegate ()
                    {
                        datos += "'" + lsvDatosCargados.Items[i].SubItems[0].Text + "',";
                    });
            }
            //and SIS_Tramite.fechaInicial BETWEEN "+fi+" AND DATEADD(day,1,"+ff+")


            try
            {
                con = new SqlConnection(strConexion);
                using (con)
                {
                    if (checkBRango.Checked)
                    {
                        ConsultarTramite = "select DISTINCT ST.fk_nroTramite, CONVERT(DATE, SIS_Tramite.fechaInicial),  E.estatus, ST.ordenJerarquico, TT.nombre, (SELECT nombreDelegacion FROM CAT_Municipio cmun  INNER JOIN  CAT_DelegacionesMunicipales   on[idDelegacionM] = cmun.[fkIdDelegacionM] WHERE idMunicipio = SUBSTRING(ST.fk_nroTramite, 13, 15)) " +
                                                "from SIS_SeguimientoTramite ST inner join CAT_Estatus E on E.idEstatus = ST.fk_estatus inner join CAT_TareasPorTramite TT on ST.fk_tareasPorTramite = TT.idTareasPorProceso inner join SIS_Tramite on st.fk_nroTramite = tramite " +
                                                "where e.estatus <> 'NO INICIADO' and SIS_Tramite.fechaInicial BETWEEN " + fi + " AND DATEADD(day,1," + ff + ")  and fk_nroTramite in (" + datos.Remove(datos.Length - 1) + ") order by fk_nroTramite, ordenJerarquico";
                         
                    }
                    else
                    {
                        ConsultarTramite = "select DISTINCT ST.fk_nroTramite, CONVERT(DATE, SIS_Tramite.fechaInicial),  E.estatus, ST.ordenJerarquico, TT.nombre, (SELECT nombreDelegacion FROM CAT_Municipio cmun  INNER JOIN  CAT_DelegacionesMunicipales   on[idDelegacionM] = cmun.[fkIdDelegacionM] WHERE idMunicipio = SUBSTRING(ST.fk_nroTramite, 13, 15)) " +
                                               "from SIS_SeguimientoTramite ST inner join CAT_Estatus E on E.idEstatus = ST.fk_estatus inner join CAT_TareasPorTramite TT on ST.fk_tareasPorTramite = TT.idTareasPorProceso inner join SIS_Tramite on st.fk_nroTramite = tramite " +
                                               "where e.estatus <> 'NO INICIADO'   and fk_nroTramite in (" + datos.Remove(datos.Length - 1) + ") order by fk_nroTramite, ordenJerarquico";
                      
                    }
                     

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

            if (cbStatus.SelectedIndex != 0)
            {
                txtFiltrar.Text = "";
                cbTarea.SelectedIndex = 0;
                cbDelegacion.SelectedIndex = 0;
                dt.DefaultView.RowFilter = $"status LIKE '{cbStatus.SelectedValue.ToString()}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = $"status LIKE '{""}%'";
            }

        }
        private void cbTarea_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTarea.SelectedIndex != 0)
            {
                txtFiltrar.Text = "";
                cbStatus.SelectedIndex = 0;
                cbDelegacion.SelectedIndex = 0;
                dt.DefaultView.RowFilter = $"tarea LIKE '{cbTarea.SelectedValue.ToString()}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = $"tarea LIKE '{""}%'";
            }
        }

        private void cbDelegacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbDelegacion.SelectedIndex != 0)
            {
                txtFiltrar.Text = "";
                cbStatus.SelectedIndex = 0;
                cbTarea.SelectedIndex = 0;
                dt.DefaultView.RowFilter = $"delegacion LIKE '{cbDelegacion.SelectedValue.ToString()}%'";
            }
            else
            {
                dt.DefaultView.RowFilter = $"delegacion LIKE '{""}%'";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarFechas_Click(object sender, EventArgs e)
        {
            DateTime t1 = DateTime.Parse(dtpFechaI.Value.ToString());
            DateTime t2 = DateTime.Parse(dtpFechaF.Value.ToString());
            DateTime FechaI = dtpFechaI.Value;
            DateTime FechaF = dtpFechaF.Value;
            string fi = FechaI.ToShortDateString(), ff = FechaF.ToShortDateString();
            int comp = DateTime.Compare(t1, t2);
           
            if (comp <= 0)
            {
                dt.DefaultView.RowFilter = string.Format("fecha >= #{0}# and fecha <= #{1}# ", Convert.ToDateTime(fi).ToString("MM/dd/yyyy"), Convert.ToDateTime(ff).ToString("MM/dd/yyyy"));
            }
            else
            {
                MessageBox.Show("Error en el rango de fecha", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelProgreso.Text = Convert.ToString(e.ProgressPercentage) + "%";
            progressBar1.Value = e.ProgressPercentage;
        }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Se cancela");
            }
            else if (e.Error != null)
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
                //filtrar
                dt.Clear();
                BuscarTramiteEnlsvConsultados();
              
                LlenarComboBox();
            }

        }

        private void checkBRango_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBRango.Checked)
            {
                dtFInicial.Enabled = true;
                dtFFinal.Enabled = true;
            }
            else
            {
                dtFInicial.Enabled = false;
                dtFFinal.Enabled = false;
            }
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarTextbox(e);
        }
        /****************************/
        public void VerificarTextbox(KeyPressEventArgs e)   //Solo permite agregar números al textbox
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

    }
}
