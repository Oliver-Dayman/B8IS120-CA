
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
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
            this.dgvFlights.Location = new System.Drawing.Point(97, 108);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.RowHeadersWidth = 62;
            this.dgvFlights.RowTemplate.Height = 33;
            this.dgvFlights.Size = new System.Drawing.Size(1084, 225);
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
            // MakeBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 745);
            this.Controls.Add(this.dtReturn);
            this.Controls.Add(this.lblRetDate);
            this.Controls.Add(this.dtDeparture);
            this.Controls.Add(this.lblDepDate);
            this.Controls.Add(this.dgvFlights);
            this.Controls.Add(this.btnSearchFlights);
            this.Name = "MakeBooking";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
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
    }
}

