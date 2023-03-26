
namespace TravelAgent
{
    partial class MakeBooking
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearchFlights = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.lblDepDate = new System.Windows.Forms.Label();
            this.dtDeparture = new System.Windows.Forms.DateTimePicker();
            this.lblRetDate = new System.Windows.Forms.Label();
            this.dtReturn = new System.Windows.Forms.DateTimePicker();
            this.dgvReturns = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturns)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchFlights
            // 
            this.btnSearchFlights.Location = new System.Drawing.Point(1208, 108);
            this.btnSearchFlights.Name = "btnSearchFlights";
            this.btnSearchFlights.Size = new System.Drawing.Size(183, 60);
            this.btnSearchFlights.TabIndex = 0;
            this.btnSearchFlights.Text = "Search Flights";
            this.btnSearchFlights.UseVisualStyleBackColor = true;
            this.btnSearchFlights.Click += new System.EventHandler(this.btnSearchFlights_Click);
            // 
            // dgvFlights
            // 
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Location = new System.Drawing.Point(98, 150);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.RowHeadersWidth = 62;
            this.dgvFlights.RowTemplate.Height = 33;
            this.dgvFlights.Size = new System.Drawing.Size(1082, 225);
            this.dgvFlights.TabIndex = 2;
            // 
            // lblDepDate
            // 
            this.lblDepDate.AutoSize = true;
            this.lblDepDate.Location = new System.Drawing.Point(97, 60);
            this.lblDepDate.Name = "lblDepDate";
            this.lblDepDate.Size = new System.Drawing.Size(137, 25);
            this.lblDepDate.TabIndex = 3;
            this.lblDepDate.Text = "Departure Date:";
            // 
            // dtDeparture
            // 
            this.dtDeparture.Location = new System.Drawing.Point(240, 56);
            this.dtDeparture.Name = "dtDeparture";
            this.dtDeparture.Size = new System.Drawing.Size(347, 31);
            this.dtDeparture.TabIndex = 4;
            // 
            // lblRetDate
            // 
            this.lblRetDate.AutoSize = true;
            this.lblRetDate.Location = new System.Drawing.Point(719, 60);
            this.lblRetDate.Name = "lblRetDate";
            this.lblRetDate.Size = new System.Drawing.Size(109, 25);
            this.lblRetDate.TabIndex = 5;
            this.lblRetDate.Text = "Return Date:";
            // 
            // dtReturn
            // 
            this.dtReturn.Location = new System.Drawing.Point(834, 56);
            this.dtReturn.Name = "dtReturn";
            this.dtReturn.Size = new System.Drawing.Size(347, 31);
            this.dtReturn.TabIndex = 6;
            // 
            // dgvReturns
            // 
            this.dgvReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturns.Location = new System.Drawing.Point(98, 439);
            this.dgvReturns.Name = "dgvReturns";
            this.dgvReturns.RowHeadersWidth = 62;
            this.dgvReturns.RowTemplate.Height = 33;
            this.dgvReturns.Size = new System.Drawing.Size(1082, 242);
            this.dgvReturns.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(96, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 33);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(96, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 33);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(504, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Departures";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(493, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Return Flights";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MakeBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 745);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvReturns);
            this.Controls.Add(this.dtReturn);
            this.Controls.Add(this.lblRetDate);
            this.Controls.Add(this.dtDeparture);
            this.Controls.Add(this.lblDepDate);
            this.Controls.Add(this.dgvFlights);
            this.Controls.Add(this.btnSearchFlights);
            this.Name = "MakeBooking";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturns)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchFlights;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Label lblDepDate;
        private System.Windows.Forms.DateTimePicker dtDeparture;
        private System.Windows.Forms.Label lblRetDate;
        private System.Windows.Forms.DateTimePicker dtReturn;
        private System.Windows.Forms.DataGridView dgvReturns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}

