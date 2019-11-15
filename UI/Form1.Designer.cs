namespace UI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnExaminar = new System.Windows.Forms.Button();
            this.BtnEntrenar = new System.Windows.Forms.Button();
            this.BtnSimular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTablaProblema = new System.Windows.Forms.ListBox();
            this.lbTablaSolucion = new System.Windows.Forms.ListBox();
            this.LbTablaSimulacion = new System.Windows.Forms.ListBox();
            this.txtIteracion = new System.Windows.Forms.TextBox();
            this.TxtErrorMax = new System.Windows.Forms.TextBox();
            this.TxtRata = new System.Windows.Forms.TextBox();
            this.txtDireccionArchivo = new System.Windows.Forms.TextBox();
            this.txtPatron = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            this.SuspendLayout();
            // 
            // chartLine
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLine.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLine.Legends.Add(legend1);
            this.chartLine.Location = new System.Drawing.Point(195, 487);
            this.chartLine.Name = "chartLine";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLine.Series.Add(series1);
            this.chartLine.Size = new System.Drawing.Size(389, 173);
            this.chartLine.TabIndex = 0;
            this.chartLine.Text = "chart1";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Location = new System.Drawing.Point(29, 245);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpiar.TabIndex = 1;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnExaminar
            // 
            this.BtnExaminar.Location = new System.Drawing.Point(153, 245);
            this.BtnExaminar.Name = "BtnExaminar";
            this.BtnExaminar.Size = new System.Drawing.Size(75, 23);
            this.BtnExaminar.TabIndex = 2;
            this.BtnExaminar.Text = "Examinar";
            this.BtnExaminar.UseVisualStyleBackColor = true;
            this.BtnExaminar.Click += new System.EventHandler(this.BtnExaminar_Click);
            // 
            // BtnEntrenar
            // 
            this.BtnEntrenar.Location = new System.Drawing.Point(269, 244);
            this.BtnEntrenar.Name = "BtnEntrenar";
            this.BtnEntrenar.Size = new System.Drawing.Size(75, 23);
            this.BtnEntrenar.TabIndex = 3;
            this.BtnEntrenar.Text = "Entrenar";
            this.BtnEntrenar.UseVisualStyleBackColor = true;
            this.BtnEntrenar.Click += new System.EventHandler(this.BtnEntrenar_Click);
            // 
            // BtnSimular
            // 
            this.BtnSimular.Location = new System.Drawing.Point(269, 300);
            this.BtnSimular.Name = "BtnSimular";
            this.BtnSimular.Size = new System.Drawing.Size(75, 23);
            this.BtnSimular.TabIndex = 4;
            this.BtnSimular.Text = "Simular";
            this.BtnSimular.UseVisualStyleBackColor = true;
            this.BtnSimular.Click += new System.EventHandler(this.BtnSimular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(298, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "RED PERCEPTRON";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Iteraciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Error maximo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rata:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Archivo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Patron:";
            // 
            // lbTablaProblema
            // 
            this.lbTablaProblema.FormattingEnabled = true;
            this.lbTablaProblema.Location = new System.Drawing.Point(391, 69);
            this.lbTablaProblema.Name = "lbTablaProblema";
            this.lbTablaProblema.Size = new System.Drawing.Size(376, 199);
            this.lbTablaProblema.TabIndex = 11;
            // 
            // lbTablaSolucion
            // 
            this.lbTablaSolucion.FormattingEnabled = true;
            this.lbTablaSolucion.Location = new System.Drawing.Point(391, 293);
            this.lbTablaSolucion.Name = "lbTablaSolucion";
            this.lbTablaSolucion.Size = new System.Drawing.Size(376, 160);
            this.lbTablaSolucion.TabIndex = 12;
            // 
            // LbTablaSimulacion
            // 
            this.LbTablaSimulacion.FormattingEnabled = true;
            this.LbTablaSimulacion.Location = new System.Drawing.Point(29, 358);
            this.LbTablaSimulacion.Name = "LbTablaSimulacion";
            this.LbTablaSimulacion.Size = new System.Drawing.Size(315, 95);
            this.LbTablaSimulacion.TabIndex = 13;
            // 
            // txtIteracion
            // 
            this.txtIteracion.Location = new System.Drawing.Point(128, 75);
            this.txtIteracion.Name = "txtIteracion";
            this.txtIteracion.Size = new System.Drawing.Size(100, 20);
            this.txtIteracion.TabIndex = 14;
            // 
            // TxtErrorMax
            // 
            this.TxtErrorMax.Location = new System.Drawing.Point(128, 113);
            this.TxtErrorMax.Name = "TxtErrorMax";
            this.TxtErrorMax.Size = new System.Drawing.Size(100, 20);
            this.TxtErrorMax.TabIndex = 15;
            // 
            // TxtRata
            // 
            this.TxtRata.Location = new System.Drawing.Point(128, 156);
            this.TxtRata.Name = "TxtRata";
            this.TxtRata.Size = new System.Drawing.Size(100, 20);
            this.TxtRata.TabIndex = 16;
            // 
            // txtDireccionArchivo
            // 
            this.txtDireccionArchivo.Location = new System.Drawing.Point(128, 201);
            this.txtDireccionArchivo.Name = "txtDireccionArchivo";
            this.txtDireccionArchivo.Size = new System.Drawing.Size(216, 20);
            this.txtDireccionArchivo.TabIndex = 17;
            // 
            // txtPatron
            // 
            this.txtPatron.Location = new System.Drawing.Point(128, 302);
            this.txtPatron.Name = "txtPatron";
            this.txtPatron.Size = new System.Drawing.Size(126, 20);
            this.txtPatron.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.txtPatron);
            this.Controls.Add(this.txtDireccionArchivo);
            this.Controls.Add(this.TxtRata);
            this.Controls.Add(this.TxtErrorMax);
            this.Controls.Add(this.txtIteracion);
            this.Controls.Add(this.LbTablaSimulacion);
            this.Controls.Add(this.lbTablaSolucion);
            this.Controls.Add(this.lbTablaProblema);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSimular);
            this.Controls.Add(this.BtnEntrenar);
            this.Controls.Add(this.BtnExaminar);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.chartLine);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartLine;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnExaminar;
        private System.Windows.Forms.Button BtnEntrenar;
        private System.Windows.Forms.Button BtnSimular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbTablaProblema;
        private System.Windows.Forms.ListBox lbTablaSolucion;
        private System.Windows.Forms.ListBox LbTablaSimulacion;
        private System.Windows.Forms.TextBox txtIteracion;
        private System.Windows.Forms.TextBox TxtErrorMax;
        private System.Windows.Forms.TextBox TxtRata;
        private System.Windows.Forms.TextBox txtDireccionArchivo;
        private System.Windows.Forms.TextBox txtPatron;
    }
}

